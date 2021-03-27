namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Consume_Tran
    {
        [Key]
        public int AutoCode { get; set; }

        public int iRec_Cd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dRec_Dt { get; set; }

        public int? iItem_Cd { get; set; }

        public int iCat_Cd { get; set; }

        public double? Qty { get; set; }

        public int? iConsume_Cd { get; set; }

        public int iFin_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }
    }
}
