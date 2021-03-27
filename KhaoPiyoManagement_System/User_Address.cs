namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iMac_Cd { get; set; }

        [StringLength(50)]
        public string sMac_Nm { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public byte? bTab { get; set; }

        public byte? bAcceptFoodOrder { get; set; }
    }
}
