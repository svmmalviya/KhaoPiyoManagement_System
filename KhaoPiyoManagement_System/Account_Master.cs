namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Master
    {
        public int? iGrp_Cd { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iAcc_Cd { get; set; }

        [StringLength(250)]
        public string sAcc_Nm { get; set; }

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

        [StringLength(50)]
        public string sMobile { get; set; }

        [StringLength(50)]
        public string sGSTIN { get; set; }

        [StringLength(250)]
        public string sAddress { get; set; }

        [StringLength(250)]
        public string sEmail { get; set; }

        public int? bActive { get; set; }
    }
}
