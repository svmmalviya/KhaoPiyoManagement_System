namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoodOrder_Rider_Status
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal AutoCode { get; set; }

        [StringLength(50)]
        public string Store_Id { get; set; }

        [StringLength(50)]
        public string Channel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UPR_Order_Id { get; set; }

        [StringLength(50)]
        public string Order_Id { get; set; }

        [StringLength(50)]
        public string Current_State { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Alt_Phone { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? User_Id { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }

        [StringLength(50)]
        public string Created { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
