namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class App_BillMaster
    {
        [Key]
        public int BillMasterId { get; set; }

        public int iBill_No { get; set; }

        public int? iComp_Cd { get; set; }

        public int? iBus_Cd { get; set; }
    }
}
