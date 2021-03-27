namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expenses_Tran
    {
        [Key]
        public int AutoCode { get; set; }

        public int iRec_Cd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dRec_Dt { get; set; }

        public int? iPay_Cd { get; set; }

        public int iExp_Cd { get; set; }

        public double? iAmount { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int iFin_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }
    }
}
