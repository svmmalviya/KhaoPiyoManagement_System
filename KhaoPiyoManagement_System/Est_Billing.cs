namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Est_Billing
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBill_No { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dPGDate { get; set; }

        [StringLength(250)]
        public string sGuset { get; set; }

        [StringLength(50)]
        public string sMobile { get; set; }

        public int? iPax { get; set; }

        public double? iRate { get; set; }

        public double? iAmount { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        public int? iItem_Cd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iOrder { get; set; }

        [StringLength(50)]
        public string sType { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iFin_Cd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public double? iDis_Amt { get; set; }

        public int? bDis { get; set; }

        public double? iGrand_Amt { get; set; }
    }
}
