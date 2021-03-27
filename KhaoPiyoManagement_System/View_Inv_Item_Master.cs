namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Inv_Item_Master
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iCat_Cd { get; set; }

        public int? iSale_Cd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iItem_Cd { get; set; }

        public double? Rate { get; set; }

        [StringLength(50)]
        public string HSN { get; set; }

        [StringLength(250)]
        public string sItem_Nm { get; set; }

        public int? iUnit_Cd { get; set; }

        public int? bActive { get; set; }

        [StringLength(50)]
        public string sCat_Nm { get; set; }

        [StringLength(50)]
        public string sUnit_Nm { get; set; }

        [StringLength(50)]
        public string sSale_Nm { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public double? Waste { get; set; }

        public byte? bGravy { get; set; }
    }
}
