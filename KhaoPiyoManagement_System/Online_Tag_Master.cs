namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Online_Tag_Master
    {
        [Key]
        public byte iTag_Cd { get; set; }

        [StringLength(250)]
        public string sTag_Nm { get; set; }
    }
}
