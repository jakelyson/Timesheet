using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace Paymatic
{
    public class PaymaticMethods
    {

        //<Summary>
        //Deletes values of tbl_TimeSheetRawNew. Prep for new values .
        //</Summary>

        public string logfile { get; set; }
        public string txtfile { get; set; }
        public bool overwrite { get; set; }
        public string errormsg { get; set; }
        public System.Windows.Forms.Form  owner { get; set; }

        public static  void  ClearTimesheetRaw() {
            PaymaticDataContext db = new PaymaticDataContext();

            var tsRawNew = from p in db.tbl_TimesheetRawNews
                           select p;

            db.tbl_TimesheetRawNews.DeleteAllOnSubmit(tsRawNew);
            db.SubmitChanges();
        }

        public static void InsertTimesheetRaw(string userid, string strName, string shift, string strPunch ) {
            PaymaticDataContext db = new PaymaticDataContext();

            tbl_TimesheetRawNew ts = new tbl_TimesheetRawNew();
            ts.UserId = userid;
            ts.Name = strName;


            ts.Shift = GetShift(shift) ;
            ts.Punch = DateTime.Parse(strPunch);

            db.tbl_TimesheetRawNews.InsertOnSubmit(ts);
            db.SubmitChanges();
        }

        public static void InsertTimesheetRaw(tbl_TimesheetRawNew ts)
        {

            PaymaticDataContext db = new PaymaticDataContext();

            db.tbl_TimesheetRawNews.InsertOnSubmit(ts);
            db.SubmitChanges();
        }

        static int GetShift(string shift) {
            int Shift= 0; 

            switch (shift)
            {
                case "FirstShift":
                    Shift = 1;
                    break;
                case "SecondShift":
                    Shift = 2;
                    break;
                case "ThirdShift":
                    Shift = 3;
                    break;
                default:
                    Shift = 0;
                    break;
            }

            return Shift;
        }

        public bool ProcessRaw(DateTime starttime, DateTime endtime) {
            if (this.logfile == null || this.txtfile == null )
            {
                return false;
            }

            if (this.overwrite && this.logfile != null  && this.txtfile != null )
            {
                try
                {
                    File.Delete(this.logfile);
                    File.Delete(this.txtfile);
                }
                catch (Exception x)
                {
                    this.errormsg = x.Message;
                    return false ;
                }
                
            }

            PaymaticDataContext db = new PaymaticDataContext();

            var raw = (from p in db.tbl_TimesheetRawNews
                       select p
                       ).OrderBy(i => i.TimeSheetRawID);

            DateTime punch = DateTime.MinValue;

            DTR dtr = new DTR();

            foreach (var item in raw)
            {
                //PrintStatus(string.Format("Processing : {0} {1}", item.UserId, item.Punch));

                if (isWithinDateRange((DateTime)item.Punch, starttime, endtime) )
                {
                    DateTime itemDate = (DateTime) item.Punch;
                    int punchType = ClassifyPunch( (int)item.Shift, (DateTime)item.Punch) ;

                    if (item.UserId != dtr.userid && dtr.userid != null )
                    {
                        saveDtr(dtr);
                        dtr = new DTR(); 
                    }

                    switch (punchType)
                    {
                        case 0: //in
                                //save on db if new userid or complete punch
                                //create a new dtr for new entry
                            if (dtr.userid != item.UserId && dtr.userid != null)
                            {
                                saveDtr(dtr);
                                dtr = new DTR();
                            }
                            else if (dtr.TimeOut != null && dtr.TimeIn != null)
                            {
                                saveDtr(dtr);
                                dtr = new DTR();
                            }

                            if (dtr.TimeIn != null && dtr.TimeOut == null)
                            {
                                dtr.TimeOut = itemDate;
                            }
                            else
                            {
                                dtr.userid = item.UserId;
                                dtr.date = itemDate.Date;
                                dtr.TimeIn = itemDate;
                            }

                            break;
                        case 1: //out
                            if (dtr.TimeIn == null)
                            {
                                //out of previous day
                                if ((int)item.Shift == 3 && ((DateTime)item.Punch).Date == starttime.Date)
                                {
                                    break; 
                                }
                                //invalid : no time in 
                                ErrorLog(item);
                                break;
                            }

                            if (dtr.TimeOut != null)
                            {
                                //is double in?
                                if (isDoubleIn(dtr, (DateTime)dtr.TimeOut, (int)item.Shift))
                                {

                                    ErrorLog(item, "Possible Double In");
                                    dtr.TimeOut = itemDate;
                                }
                                else
                                {
                                    //possible no time in?
                                    ErrorLog(item);
                                }
                            }
                            else
                            {
                                //valid, save if on next run, in is encountered
                                dtr.TimeOut = itemDate;
                            }
                            break;
                        default:
                            break;
                    } //switch
                }
            }

            //save last item
            if (dtr.TimeOut != null && dtr.TimeIn != null)
            {
                saveDtr(dtr);
            }

            //PrintStatus ("Attendance");
            return true;
        }

        //private void PrintStatus(string msg) {
        //    if (this.owner != null)
        //    {
        //        this.owner.Text = msg;
        //    }
        //}

        private void ErrorLog(tbl_TimesheetRawNew  item, string msg = null) {
            StreamWriter sw = new StreamWriter(this.logfile , true);
            sw.WriteLine(String.Format("{0:0000}, {2},  Punch: {1: MM-dd-yyyy HH:mm}", item.UserId, item.Punch, msg ==null? "time out no time in":msg));
            sw.Close();
        }

        private static bool isDoubleIn(DTR dtr, DateTime punch,int shift) {
            bool retval = false;
            switch (shift)
            {
                case 3: //third shift
                    TimeSpan oneday = new TimeSpan(1, 0, 0, 0);
                    DateTime nextday =(DateTime) dtr.date + oneday;

                    //same date or next day before 3 am
                    if (dtr.date == punch.Date  || (punch.Date ==  nextday && punch.Hour < 1))
                    {
                        retval = true;
                    }
                    
                    break;
                default:
                    //firstshift and secondshift
                    if (dtr.date == punch.Date)
                    {
                        retval = true;
                    }
                    break;
            }

            return retval;
        }

        private static bool isWithinDateRange(DateTime date, DateTime starttime, DateTime endtime) {
            return  date.Date >= starttime.Date && date.Date <= endtime.Date;
        }

        private static int ClassifyPunch(int shift, DateTime punch) {
            int cout = -1 ;

            switch (shift)
            {
                case 1: //first shift 6-3PM

                    if (punch.Hour <= 10) //in: anytime before 10am 
                    {
                        cout = 0;
                    }
                    else if (punch.Hour > 10) //out: anytime after 10am
                    {
                        cout = 1;
                    }

                    break;
                case 2:
                    if (punch.Hour >= 6 && punch.Hour <= 18) // in: anytime before 5PM
                    {
                        cout = 0;
                    }
                    else //anytime after 5PM and before 6AM out
                    {
                        cout = 1;
                    }
                    
                    break;

                case 3:

                    if (punch.Hour >= 17 || punch.Hour <= 2) // anytime between 6PM and 2AM
                    {
                        cout = 0;
                    }
                    else {
                        cout = 1;
                    }
                    break;
                default:
                    break;
            }

            return cout ;
        }

        private bool saveDtr(DTR dtr) {

            if (dtr.TimeIn == null ||  dtr.TimeOut == null)
            {
                //invalid dtr 
                StreamWriter sw = new StreamWriter(this.logfile, true);
                sw.WriteLine(string.Format("{0:0000}, invalid entry Time In: {1:MM-dd-yyyy HH:mm}  Time Out: {2:dd-MM-yyyy HH:mm}", 
                                    dtr.userid, dtr.TimeIn.ToString(), dtr.TimeOut.ToString()  ));
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(this.txtfile, true);
                sw.Write(String.Format("{0:0000},", dtr.userid));
                sw.Write(String.Format("{0:MM-dd-yyyy},", dtr.date));
                //sw.Write(String.Format("{0},", dtr.TimeIn));
                sw.Write(String.Format("{0:MM-dd-yyyy HH:mm},", dtr.TimeIn));
                sw.Write("NULL,NULL,");
                sw.Write(String.Format("{0:MM-dd-yyyy HH:mm},", dtr.TimeOut));
                sw.Write("NULL,NULL,0");
                sw.WriteLine();
                sw.Close();
            }        

            return true;
        }

    }
}
