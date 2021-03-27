namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Online_Item_Master
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string sRefId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iItem_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public byte? bOrder { get; set; }

        public byte? bRecommd { get; set; }

        public byte? bZomato { get; set; }

        public byte? bSwiggy { get; set; }

        public byte? bAmazon { get; set; }

        [StringLength(250)]
        public string sTag_Nm { get; set; }

        public byte? bCharge { get; set; }
    }
}
