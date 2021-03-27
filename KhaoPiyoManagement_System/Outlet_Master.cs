namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Outlet_Master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iCode { get; set; }

        [Required]
        [StringLength(250)]
        public string sName { get; set; }

        [StringLength(250)]
        public string sCity { get; set; }

        [StringLength(250)]
        public string sAddress { get; set; }

        [StringLength(250)]
        public string sRefId { get; set; }

        public byte? bZomato { get; set; }

        public byte? bSwiggy { get; set; }

        public byte? bAmazon { get; set; }

        public byte? bActive { get; set; }

        public byte? bOrder { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public int? iComp_Cd { get; set; }

        public int? iBus_Cd { get; set; }

        public byte? bZomato_Order { get; set; }

        public byte? bSwiggy_Order { get; set; }

        public byte? bAmazon_Order { get; set; }
    }
}
