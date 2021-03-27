namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback_Tran
    {
        [Key]
        public int iFeedback_Trans_CD { get; set; }

        public int iFeed_Cd { get; set; }

        public int? iAnswer { get; set; }

        public int iBill_No { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        [StringLength(50)]
        public string sGuest_Name { get; set; }

        [StringLength(15)]
        public string sMobile { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDOA { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dDOB { get; set; }

        [StringLength(200)]
        public string sEmail { get; set; }

        [StringLength(250)]
        public string sCustomerReview { get; set; }
    }
}
