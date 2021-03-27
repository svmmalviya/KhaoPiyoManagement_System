namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_Group_Master
    {
        [Key]
        public int AutoCode { get; set; }

        [StringLength(50)]
        public string sRefId { get; set; }

        public int? iItemGrp_Cd { get; set; }

        [StringLength(100)]
        public string sItemGrp_Nm { get; set; }

        public int? iItem_Cd { get; set; }

        public int iItemOpt_Cd { get; set; }

        [StringLength(250)]
        public string sTitle { get; set; }

        public double? Rate1 { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public byte? bActive { get; set; }

        public byte? iMin_Value { get; set; }

        public byte? iMax_Value { get; set; }
    }
}
