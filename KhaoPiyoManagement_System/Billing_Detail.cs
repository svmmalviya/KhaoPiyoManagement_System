namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Billing_Detail
    {
        [Key]
        public int AutoCode { get; set; }

        public int iBill_No { get; set; }

        public int? iItem_Cd { get; set; }

        [StringLength(50)]
        public string HSN { get; set; }

        public double? Rate { get; set; }

        public double? Qty { get; set; }

        public double? Amount { get; set; }

        public double? DisPer { get; set; }

        public double? DisAmt { get; set; }

        public double? ExtraAmt { get; set; }

        public double? GSTPer { get; set; }

        public double? GSTAmt { get; set; }

        public double? CessPer { get; set; }

        public double? CessAmt { get; set; }

        public double? Total { get; set; }

        [StringLength(250)]
        public string ItemDesc { get; set; }

        public int iFin_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? bKOTPrint { get; set; }

        public int? iSale_Cd { get; set; }

        public int? iItemSr_No { get; set; }

        public int? iKOT_No { get; set; }

        public double? TaxAmt { get; set; }

        public DateTime? dPunch_Time { get; set; }

        public byte? bReady { get; set; }
    }
}
