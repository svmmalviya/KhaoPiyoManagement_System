namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guest_Master
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iGuest_Cd { get; set; }

        [StringLength(250)]
        public string sGuest_Nm { get; set; }

        [StringLength(250)]
        public string sMobile { get; set; }

        [StringLength(250)]
        public string sEmail { get; set; }

        [StringLength(250)]
        public string sWebsite { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDOB { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDOA { get; set; }

        [StringLength(250)]
        public string sAddress { get; set; }

        [StringLength(250)]
        public string sComment { get; set; }

        public int? Point { get; set; }

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
