namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class State_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iState_Cd { get; set; }

        [StringLength(250)]
        public string sState_Nm { get; set; }

        public int? StateCode { get; set; }
    }
}
