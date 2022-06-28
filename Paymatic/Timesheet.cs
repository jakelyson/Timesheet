using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymatic
{
    public class DTR
    {
        public string userid { get; set; }
        public Nullable<DateTime> date { get; set; }
        public Nullable<DateTime> TimeIn { get; set;}
        public Nullable<DateTime> BreakOut { get; set; }
        public Nullable<DateTime> Resume { get; set; }
        public Nullable<DateTime> TimeOut { get; set; }
        public Nullable<DateTime> OT { get; set; }
        public Nullable<DateTime> Done { get; set; }
        public Nullable<Single> HoursWork { get; set; }
    }
}
