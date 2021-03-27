namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Billing_Master
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBill_No { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dBill_Dt { get; set; }

        public int? iTab_Cd { get; set; }

        [StringLength(250)]
        public string sBillType { get; set; }

        [StringLength(250)]
        public string sGuest_Nm { get; set; }

        [StringLength(50)]
        public string sMobile { get; set; }

        public int? iPax { get; set; }

        [StringLength(50)]
        public string GSTIN { get; set; }

        public int? iAttd_Cd { get; set; }

        public double? TQty { get; set; }

        public byte? bNC { get; set; }

        [StringLength(250)]
        public string sNCReason { get; set; }

        public double? NCAmt { get; set; }

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

        public int? iDis_Cd { get; set; }

        public byte? bPrint { get; set; }

        public byte? bOpen { get; set; }

        public byte? bLessStock { get; set; }

        public DateTime? INTime { get; set; }

        public byte? bVoid { get; set; }

        [StringLength(250)]
        public string sVoidReason { get; set; }

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

        public int? iAcc_Cd { get; set; }

        [StringLength(50)]
        public string sDis_Type { get; set; }

        public int? iRef_Cd { get; set; }

        public double? iWayOffAmt { get; set; }

        [StringLength(250)]
        public string iWayOffRemark { get; set; }

        public double? iTipAmt { get; set; }

        [StringLength(250)]
        public string iTipRemark { get; set; }

        public double? iDonationAmt { get; set; }

        [StringLength(250)]
        public string iDonationRemark { get; set; }

        public int? iMore_Cd { get; set; }
    }
}
