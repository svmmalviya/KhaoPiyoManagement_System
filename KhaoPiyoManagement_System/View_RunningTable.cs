namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_RunningTable
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

        [StringLength(250)]
        public string sTab_Nm { get; set; }

        public byte? bPrint { get; set; }

        public double? iGrand_Amt { get; set; }

        public int? iPax { get; set; }

        public DateTime? INTime { get; set; }

        [StringLength(250)]
        public string sTab_Cat_Nm { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }
    }
}
