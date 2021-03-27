namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendor_Master
    {
        public int? iGrp_Cd { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iVend_Cd { get; set; }

        [StringLength(255)]
        public string sVend_Nm { get; set; }

        [StringLength(255)]
        public string sAddress { get; set; }

        [StringLength(255)]
        public string GSTNo { get; set; }

        public int? iState_Cd { get; set; }

        [StringLength(200)]
        public string Mobile { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        [StringLength(250)]
        public string PANNo { get; set; }

        [StringLength(250)]
        public string ConPerson { get; set; }

        [StringLength(250)]
        public string CPerMob { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public int? bActive { get; set; }

        public int? sType { get; set; }

        [StringLength(250)]
        public string sBank { get; set; }

        [StringLength(50)]
        public string sBankAcc { get; set; }

        [StringLength(50)]
        public string IFSC { get; set; }
    }
}
