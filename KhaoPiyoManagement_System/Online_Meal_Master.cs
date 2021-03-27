namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Online_Meal_Master
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string sRefId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iMeal_Cd { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public byte? bOrder { get; set; }

        public byte? iOrder { get; set; }
    }
}
