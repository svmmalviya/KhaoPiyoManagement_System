namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_Item_Master
    {
        [Key]
        public int AutoCode { get; set; }

        public int iCat_Cd { get; set; }

        public int? iSale_Cd { get; set; }

        public int iItem_Cd { get; set; }

        [StringLength(250)]
        public string sItem_Nm { get; set; }

        public double? Rate { get; set; }

        [StringLength(50)]
        public string HSN { get; set; }

        public int? iUnit_Cd { get; set; }

        public int? bActive { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public double? Waste { get; set; }

        public byte? bGravy { get; set; }
    }
}
