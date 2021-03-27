namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillPrint_Record
    {
        [Key]
        public int iCode { get; set; }

        [StringLength(10)]
        public string RNo { get; set; }

        public int? iBill_No { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int iFin_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public double? Amount { get; set; }
    }
}
