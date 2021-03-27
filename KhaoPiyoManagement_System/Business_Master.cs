namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Business_Master
    {
        [Key]
        public byte iBus_Cd { get; set; }

        [StringLength(250)]
        public string sBus_Nm { get; set; }

        public byte? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public bool? bActive { get; set; }
    }
}
