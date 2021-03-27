namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fin_Yr_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iFin_Yr_Cd { get; set; }

        [StringLength(50)]
        public string sFin_Yr_Nm { get; set; }

        public int? bDefault { get; set; }
    }
}
