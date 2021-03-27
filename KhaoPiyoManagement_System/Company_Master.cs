namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Company_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        public int? ResturantID { get; set; }

        [StringLength(250)]
        public string sComp_Nm { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string TagLine { get; set; }

        [StringLength(250)]
        public string GSTIN { get; set; }

        [StringLength(250)]
        public string MobileNo { get; set; }

        [StringLength(250)]
        public string ImgName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        [StringLength(50)]
        public string DBaseNm { get; set; }

        [StringLength(50)]
        public string RefCode { get; set; }
    }
}
