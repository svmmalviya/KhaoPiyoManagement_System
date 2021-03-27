namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Loyalty_Master
    {
        [Key]
        public int AutoCode { get; set; }

        public int iCode { get; set; }

        public int iComp_Cd { get; set; }

        public int iBus_Cd { get; set; }

        public double? MaxEarn { get; set; }

        [StringLength(50)]
        public string PointSystem { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dFromDt { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dToDt { get; set; }

        public byte? bMaxPer { get; set; }

        public byte? bRedimBill { get; set; }

        public double? MaxValue { get; set; }

        public byte? bBirthdayPer { get; set; }

        public byte? bBirthdayBill { get; set; }

        public double? BirthdayValue { get; set; }

        public byte? bAnniversaryPer { get; set; }

        public byte? bAnniversaryBill { get; set; }

        public double? AnniversaryValue { get; set; }

        public byte? bActive { get; set; }

        public int? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public double? MinValue { get; set; }

        public double? PerValue { get; set; }

        public byte? bRoundOff { get; set; }

        public double? FromAmt { get; set; }

        public double? ToAmt { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public double? Value { get; set; }
    }
}
