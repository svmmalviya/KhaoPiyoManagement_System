namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataCopy")]
    public partial class DataCopy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        public int? iComp_Cd { get; set; }

        public int? iBus_Cd { get; set; }
    }
}
