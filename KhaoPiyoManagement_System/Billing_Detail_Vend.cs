namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Billing_Detail_Vend
    {
        public int? iCat_Cd { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iFin_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public int? iSale_Cd { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iItemSr_No { get; set; }

        public double? TaxAmt { get; set; }
    }
}
