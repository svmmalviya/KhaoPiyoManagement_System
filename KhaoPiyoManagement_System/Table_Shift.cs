namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table_Shift
    {
        [Key]
        public int AutoCode { get; set; }

        public int iBill_No { get; set; }

        public int iOld_Tab_Cd { get; set; }

        public int iNew_Tab_Cd { get; set; }

        [StringLength(250)]
        public string sReason { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int iFin_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }
    }
}
