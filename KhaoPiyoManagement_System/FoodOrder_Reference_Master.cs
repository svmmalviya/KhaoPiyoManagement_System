namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodOrder_Reference_Master
    {
        [Column(TypeName = "numeric")]
        public decimal AutoCode { get; set; }

        [Key]
        [StringLength(250)]
        public string Reference_Id { get; set; }

        [StringLength(500)]
        public string sError { get; set; }
    }
}
