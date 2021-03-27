namespace KhaoPiyoManagement_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Configration_Master
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iCodeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iComp_Cd { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iBus_Cd { get; set; }

        public byte? bCloud { get; set; }

        public byte? bTab { get; set; }

        public byte? bLocation { get; set; }

        public byte? bMCode { get; set; }

        public byte? BillSeries { get; set; }

        public byte? bShowBillDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OpDate { get; set; }

        public byte? bKOTPrint { get; set; }

        public byte? bBillPrint { get; set; }

        public byte? iKOTNo { get; set; }

        public byte? iBillNo { get; set; }

        [StringLength(50)]
        public string sKOTLang { get; set; }

        [StringLength(50)]
        public string sKOTType { get; set; }

        [StringLength(50)]
        public string sBillPrinterType { get; set; }

        [StringLength(50)]
        public string sBillTax { get; set; }

        [StringLength(50)]
        public string sBillType { get; set; }

        public byte? bKOTMsg { get; set; }

        public byte? bBillMsg { get; set; }

        public byte? iUser_Cd { get; set; }

        public DateTime? dUpdate_Dt { get; set; }

        public byte? bAddItem { get; set; }

        public byte? bShowRemove { get; set; }

        public byte? bLockRate { get; set; }

        [StringLength(6)]
        public string SMSSenderID { get; set; }

        public string SMSKey { get; set; }

        public string SMSLang { get; set; }

        [StringLength(50)]
        public string SMSNo { get; set; }

        public byte? bDeleteSMS { get; set; }

        public byte? bKOTPreview { get; set; }

        public byte? bBillPreview { get; set; }

        public byte? bQTPrint { get; set; }

        [StringLength(50)]
        public string sQTPrinterType { get; set; }

        public byte? bReverse { get; set; }

        public byte? TTop { get; set; }

        public byte? THigh { get; set; }

        public byte? TWdth { get; set; }

        public byte? bPax { get; set; }

        public byte? bTabBillPrint { get; set; }

        public byte? bItemFromCode { get; set; }

        public byte? bLoyalty { get; set; }

        public byte? bEBill { get; set; }

        public byte? bBillSplit { get; set; }

        public byte? bQRCode { get; set; }

        public byte? bMobileNo { get; set; }

        public byte? bGuestName { get; set; }

        [StringLength(50)]
        public string sEBillType { get; set; }

        public byte? bAttendent { get; set; }

        public byte? bOnlineOrder { get; set; }

        public string TokenKey { get; set; }

        public byte? iSMSType { get; set; }

        public byte? bDeleteKOTPrint { get; set; }
    }
}
