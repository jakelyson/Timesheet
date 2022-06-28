using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

//using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Excel;
using xls =  Microsoft.Office.Interop.Excel;
using System.IO;
using Paymatic;

namespace TimeSheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDate();
			
        }

        private void LoadDate(int shift = 0) {

            DateTime now = DateTime.Now.Date;
            int d = now.Day;
            int m = now.Month;
            int y = now.Year;


            if (d >= 11 && d <= 25 )
            {
                
                dtpStart.Value = DateTime.Parse(string.Format("{1}-{0}-{2}", 26, now.AddMonths(-1).Month, now.AddMonths(-1).Year));

                if (shift == 3)
                {
                    dtpEnd.Value = DateTime.Parse(string.Format("{1}-{0}-{2}",  11,m, y));
                }
                else
                {
                    dtpEnd.Value = DateTime.Parse(string.Format("{1}-{0}-{2}", 10,m, y));
                }
                
            }
            else
            {
                if (d < 11)
                {
                    m = now.AddMonths(-1).Month;
                    y = now.AddMonths(-1).Year;
                }

                dtpStart.Value = DateTime.Parse(string.Format("{1}-{0}-{2}", 11,m, y ));

                if (shift == 3)
                {
                    dtpEnd.Value = DateTime.Parse(string.Format("{1}-{0}-{2}", 26,m, y));
                }
                else
                {
                    dtpEnd.Value = DateTime.Parse(string.Format("{1}-{0}-{2}", 25, m, y));
                }
            }
        }

        private void LoadExcel(string path) {

            //exit if path is empty
            if (path =="")
            {
                return;
            }

            try
            {
                PaymaticMethods.ClearTimesheetRaw();
                LoadExcelEx(path);
            }
            finally {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            
        }

        private void LoadExcelEx(string path) {

			//Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
			xls.Application xl = new xls.Application();
			
            xls.Workbooks wbs = xl.Workbooks;

			xls.Workbook wb = wbs.Open(path);

			xls.Worksheet ws = wb.Worksheets["Sheet1"];


            //start with a2. work down

            //line
            int irow = 2;

            while (ws.Range["A"+irow].Value != null)
            {
				xls.Range rs = ws.Range["A" + irow, "Z" + irow];

                string userid = rs.Cells[1,1].Text;
                string strName = rs.Cells[1, 3].Text;
                string shift = rs.Cells[1, 4].Text;
                string strDate = rs.Cells[1, 5].Text;

                int x = 6;

                while (rs.Cells[1, x].Text != "" )
                {

                    this.Text = string.Format ("Raw Process : {0} {1}",userid , rs.Cells[1, x].Text);
                    PaymaticMethods.InsertTimesheetRaw(userid, strName, shift, 
                                        string.Format("{0} {1}", strDate, rs.Cells[1, x].Text) );

                    x++;

                }

                //close range
                Marshal.FinalReleaseComObject(rs);

                irow += 1; 
            }

                
            //release all com objects 
            Marshal.FinalReleaseComObject(ws);

            wb.Close();
            Marshal.FinalReleaseComObject(wb);

            xl.Quit();
            Marshal.FinalReleaseComObject(xl);


        }

        private string GetPath()
        {

            string output = ""; 
            OpenFileDialog dg = new OpenFileDialog();

            dg.CheckPathExists = true;
            dg.CheckFileExists = true;
            dg.Filter = "Microsoft Excel|*.xlsx";
            try
            {
                dg.ShowDialog();
                if (dg.FileName != "")
                {
                    output =  dg.FileName;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return output;
            
        }

        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFilename.Text = GetPath();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            LoadExcel(txtFilename.Text);

            this.Text = "Creating Text File";

            Thread prRaw = new Thread(ProcessRaw);
            prRaw.IsBackground = true;
            prRaw.Start();

            
        }

        private void ProcessRaw() {
            PaymaticMethods pm = new PaymaticMethods();

			pm.logfile = @"D:\Joel Files\logfile.txt";  /*"d:\\logfile.txt";*/
			pm.txtfile = @"D:\Joel Files\txtfile.txt"; /* "d:\\txtfile.txt";
*/            pm.overwrite = !chkAppend.Checked; 
            pm.owner = this;

            if (pm.ProcessRaw(dtpStart.Value.Date, dtpEnd.Value.Date))
            {
                MessageBox.Show("Compute Done");
            }
            else
            {
                MessageBox.Show( pm.errormsg == null?  "Error!": pm.errormsg);
            }
        }

        private void CheckedChanged(object sender, EventArgs e) 
        {
            RadioButton btn = (RadioButton) sender;
            switch (btn.Name)
            {
                case "radioButton1":
                    LoadDate(1);
                    break;
                default:
                    LoadDate(3);
                    break;
            }

        }

		private void button1_Click(object sender, EventArgs e) //upload to server
		{

		}
	}
}
