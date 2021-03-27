namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Online_Master
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iOnline_Cd { get; set; }

        [StringLength(50)]
        public string sOnline_Nm { get; set; }

        public double? Dis { get; set; }

        public double? Comm { get; set; }

        public double? GST { get; set; }

        public double? PG { get; set; }

        public int? iAcc_Cd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }
    }
}
