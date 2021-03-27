namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Advance_Tran
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iAdv_Cd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dAdv_Dt { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dMain_Dt { get; set; }

        [StringLength(250)]
        public string sGuest { get; set; }

        [StringLength(250)]
        public string sMobile { get; set; }

        [StringLength(250)]
        public string sPax { get; set; }

        [StringLength(250)]
        public string sTime { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        public int? bAdvance { get; set; }

        public int? iPay_Cd { get; set; }

        public double? iAmount { get; set; }

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

        public int? bActive { get; set; }
    }
}
