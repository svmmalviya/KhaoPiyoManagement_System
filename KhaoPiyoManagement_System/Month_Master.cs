namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Month_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iMnth_Cd { get; set; }

        [StringLength(50)]
        public string sMnth_Nm { get; set; }

        public int? dDays { get; set; }
    }
}
