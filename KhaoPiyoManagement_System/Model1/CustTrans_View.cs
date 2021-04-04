using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhaoPiyoManagement_System.Models
{
    public class Cust_View_Tran
    {
        public int iBill_No { get; set; }
        public string dBill_Dt { get; set; }
        public int iTab_Cd { get; set; }
        public string sGuest_Nm { get; set; }
        public string sMobile { get; set; }
        public int iPax { get; set; }
        public string GSTIN { get; set; }
        public int iAttd_Cd { get; set; }
        public double TQty { get; set; }
        public int bNC { get; set; }
        public string sNCReason { get; set; }
        public double TAmt { get; set; }
        public double TGST { get; set; }
        public object TCESS { get; set; }
        public double TDiscount { get; set; }
        public double TRoundOff { get; set; }
        public double iGrand_Amt { get; set; }
        public int bDiscount { get; set; }
        public string sDis { get; set; }
        public object iDis_Cd { get; set; }
        public int bPrint { get; set; }
        public int bOpen { get; set; }
        public int bLessStock { get; set; }
        public DateTime INTime { get; set; }
        public int bVoid { get; set; }
        public int iFin_Cd { get; set; }
        public int iComp_Cd { get; set; }
        public int iBus_Cd { get; set; }
        public int iUser_Cd { get; set; }
        public DateTime dUpdate_Dt { get; set; }
        public string sAttd_Nm { get; set; }
        public object sDis_Nm { get; set; }
        public string sItem_Nm { get; set; }
        public int iItem_Cd { get; set; }
        public string HSN { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Amount { get; set; }
        public double DisPer { get; set; }
        public double DisAmt { get; set; }
        public object GSTPer { get; set; }
        public object GSTAmt { get; set; }
        public object CessPer { get; set; }
        public object CessAmt { get; set; }
        public double Total { get; set; }
        public string ItemDesc { get; set; }
        public int bKOTPrint { get; set; }
        public int iItemSr_No { get; set; }
        public int iSale_Cd { get; set; }
        public int iKOT_No { get; set; }
        public double TaxAmt { get; set; }
        public string sType { get; set; }
        public object iAcc_Cd { get; set; }
        public string sDis_Type { get; set; }
        public int iCat_Cd { get; set; }
        public string sCat_Nm { get; set; }
        public int iMeal_Cd { get; set; }
        public string sMeal_Nm { get; set; }
        public double TDiscountValue { get; set; }
        public string sTab_Nm { get; set; }
        public double ExtraAmt { get; set; }
        public double TExtra { get; set; }
        public double NCAmt { get; set; }
        public int? iRef_Cd { get; set; }
        public double? iTipAmt { get; set; }
        public string iWayOffRemark { get; set; }
        public double? iDonationAmt { get; set; }
        public string iTipRemark { get; set; }
        public string MCode { get; set; }
        public string sTab_Cat_Nm { get; set; }
        public object sVoidReason { get; set; }
        public string sBillType { get; set; }
        public string sRef_Nm { get; set; }
        public DateTime dPunch_Time { get; set; }
        public int bReady { get; set; }
        public int iTab_Cat_Cd { get; set; }
        public int AutoCode { get; set; }
        public int bDepend { get; set; }
        public object iDep_Cat_Cd { get; set; }
        public int bKDS { get; set; }
        public string iDonationRemark { get;  set; }
        public double iWayOffAmt { get;  set; }
    }
}