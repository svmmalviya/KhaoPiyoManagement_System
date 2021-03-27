namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Billing_Master_Vend
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBill_No { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dBill_Dt { get; set; }

        [StringLength(250)]
        public string sBillSRNo { get; set; }

        public int? iVend_Cd { get; set; }

        public double? TQty { get; set; }

        public double? TAmt { get; set; }

        public double? TGST { get; set; }

        public double? TCESS { get; set; }

        public double? TDiscount { get; set; }

        public double? TDiscountValue { get; set; }

        public double? TExtra { get; set; }

        public double? TRoundOff { get; set; }

        public double? iGrand_Amt { get; set; }

        public byte? bDiscount { get; set; }

        [StringLength(50)]
        public string sDis { get; set; }

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

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        [StringLength(50)]
        public string sType { get; set; }
    }
}
