namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iUser_Cd { get; set; }

        [StringLength(50)]
        public string sUser_Nm { get; set; }

        [StringLength(250)]
        public string sFull_nm { get; set; }

        public int? bAdmin { get; set; }

        [StringLength(50)]
        public string sPIN { get; set; }

        [StringLength(250)]
        public string sPassword { get; set; }

        public byte? bAttd { get; set; }

        public int? iAttd_Cd { get; set; }

        public byte? bMultiCompany { get; set; }
    }
}
