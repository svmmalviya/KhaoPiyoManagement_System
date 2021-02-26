using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoPiyoManagement_System.Models
{
    public class ItemSummary
    {
        public double TAmt { get; set; }
        public double TTax { get; set; }
        public double TQty { get; set; }
        public double TDisAmt { get; set; }
        public string item { get; set; }
    }

    public class DashboardSummary
    {
        public string billcount { get; set; }
        public string expences { get; set; }
        public string sale { get; set; }
        public string guest { get; set; }
        public List<string> chartLabels { get; set; }
        public List<string> chartData { get; set; }
    }
    public class AuditReport
    {
        public string sItem_Nm { get; set; }
        public string UserName { get; set; }
        public DateTime UpdateDate { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public int iBill_No { get; set; }
        public double TAmt { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}