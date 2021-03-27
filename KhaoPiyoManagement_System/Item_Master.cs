namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_Master
    {
        [Key]
        public int AutoCode { get; set; }

        public int? iCat_Cd { get; set; }

        public int? iSale_Cd { get; set; }

        public int iItem_Cd { get; set; }

        [StringLength(250)]
        public string sItem_Nm { get; set; }

        public double? Rate { get; set; }

        [StringLength(50)]
        public string HSN { get; set; }

        [StringLength(250)]
        public string MCode { get; set; }

        public int? iMeal_Cd { get; set; }

        [StringLength(250)]
        public string Hindi_Nm { get; set; }

        public int? bVeg { get; set; }

        public double? Rate1 { get; set; }

        public double? Rate2 { get; set; }

        public double? Rate3 { get; set; }

        public double? Rate4 { get; set; }

        public double? Rate5 { get; set; }

        public int? bActive { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public int? bTop { get; set; }

        public int? bDisApply { get; set; }

        public byte? bQRCode { get; set; }

        [StringLength(250)]
        public string sDesc { get; set; }

        [StringLength(250)]
        public string sLabel_Nm { get; set; }

        [StringLength(250)]
        public string sQR_Nm { get; set; }

        public int? iItemOrder { get; set; }

        public byte? bFoodOrder { get; set; }

        public byte? bKDS { get; set; }

        [StringLength(250)]
        public string sOnline_Nm { get; set; }
    }
}
