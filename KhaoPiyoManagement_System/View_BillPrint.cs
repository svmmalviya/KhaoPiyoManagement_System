namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_BillPrint
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBill_No { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dBill_Dt { get; set; }

        public int? iTab_Cd { get; set; }

        [StringLength(250)]
        public string sGuest_Nm { get; set; }

        [StringLength(50)]
        public string sMobile { get; set; }

        [StringLength(250)]
        public string sItem_Nm { get; set; }

        public int? iItem_Cd { get; set; }

        [StringLength(50)]
        public string HSN { get; set; }

        public double? Rate { get; set; }

        public double? TQty { get; set; }

        public double? TAmount { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iCat_Cd { get; set; }

        [StringLength(50)]
        public string sCat_Nm { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iFin_Cd { get; set; }

        public double? TDis { get; set; }

        public int? TTax { get; set; }

        public int? iPax { get; set; }

        [StringLength(50)]
        public string GSTIN { get; set; }

        [StringLength(50)]
        public string sAttd_Nm { get; set; }

        public byte? bDiscount { get; set; }

        [StringLength(250)]
        public string sTab_Nm { get; set; }

        public double? TRoundOff { get; set; }

        public double? iGrand_Amt { get; set; }

        public double? TExtra { get; set; }

        public double? TTot { get; set; }

        public double? TTExtra { get; set; }

        public byte? bVoid { get; set; }

        public byte? bOpen { get; set; }

        public double? iWayOffAmt { get; set; }

        [StringLength(250)]
        public string sTab_Cat_Nm { get; set; }

        [StringLength(250)]
        public string sBillType { get; set; }

        public int? iTab_Cat_Cd { get; set; }

        public byte? bDepend { get; set; }

        public byte? iDep_Cat_Cd { get; set; }
    }
}
