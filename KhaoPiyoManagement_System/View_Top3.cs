namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Top3
    {
        [StringLength(250)]
        public string sItem_Nm { get; set; }

        public double? TotQty { get; set; }

        [StringLength(250)]
        public string MCode { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iItem_Cd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        [StringLength(50)]
        public string sMobile { get; set; }

        public byte? bNC { get; set; }

        public byte? bOpen { get; set; }

        public byte? bVoid { get; set; }
    }
}
