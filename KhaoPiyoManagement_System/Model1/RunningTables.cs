using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoPiyoManagement_System.Models
{
    public class RunningTables
    {
        public List<string> tablecatname { get; set; }
        public List<tableCode> tableDetails { get; set; }
    }



    public class tableCode
    {
        public string itab_cd { get; set; }
        public string stab_Nm { get; set; }
        public string stab_Cat_Nm { get; set; }

    }

    public class TableDetails
    {

        public string tabno { get; set; }
        public string billno { get; set; }
        public string billdate { get; set; }
        public string guestname { get; set; }
        public string mobileno { get; set; }
        public string waiter { get; set; }
        public string pax { get; set; }
        public string rate { get; set; }
        public string qty { get; set; }
        public string amount { get; set; }
        public string total { get; set; }
        public string discount { get; set; }
        public string tax { get; set; }
        public string roundoff { get; set; }
        public string grandtotal { get; set; }
        public string tabno_cd { get; set; }
        public string itemname { get; set; }
        public string cat { get; set; }
        public string totqty { get; set; }
        public string price { get; set; }
    }

}