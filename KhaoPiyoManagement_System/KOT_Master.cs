namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KOT_Master
    {
        [Key]
        public int KotMasterId { get; set; }

        public int iUser_Cd { get; set; }

        public int iTab_Cd { get; set; }

        public int iItem_cd { get; set; }

        public double Qty { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        public int? iComp_Cd { get; set; }

        public int? iBus_Cd { get; set; }

        public int? iPax { get; set; }

        public int? bProcess { get; set; }

        [StringLength(250)]
        public string sGuestName { get; set; }

        [StringLength(15)]
        public string sMobile { get; set; }
    }
}
