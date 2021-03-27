namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Pay_Vend
    {
        [StringLength(255)]
        public string sVend_Nm { get; set; }

        [StringLength(50)]
        public string sPay_Nm { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iRec_Cd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dRec_Dt { get; set; }

        public int? iPay_Cd { get; set; }

        public int? iVend_Cd { get; set; }

        public double? iAmount { get; set; }

        public int? bBank { get; set; }

        [StringLength(50)]
        public string Cheque { get; set; }

        public int? iBank_Cd { get; set; }

        [StringLength(50)]
        public string sBank_Nm { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iFin_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }
    }
}
