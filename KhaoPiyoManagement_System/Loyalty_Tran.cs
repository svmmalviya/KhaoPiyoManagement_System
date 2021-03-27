namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Loyalty_Tran
    {
        [Key]
        public int AutoCode { get; set; }

        public int? iTran_No { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDate { get; set; }

        [StringLength(50)]
        public string sMobile { get; set; }

        public double? iValue { get; set; }

        public double? Point { get; set; }

        [StringLength(50)]
        public string sType { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public byte? bActive { get; set; }

        public byte? bAdd { get; set; }

        [StringLength(250)]
        public string sRemark { get; set; }

        public int? iLoyalty_Cd { get; set; }
    }
}
