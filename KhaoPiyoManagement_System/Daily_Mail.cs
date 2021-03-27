namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Daily_Mail
    {
        [Key]
        public int AutoCode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dMailDate { get; set; }

        public int? iComp_Cd { get; set; }

        public int? iBus_Cd { get; set; }
    }
}
