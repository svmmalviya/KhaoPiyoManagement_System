using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Classes;
using KhaoPiyoManagement_System.Models;
using Microsoft.Ajax.Utilities;

namespace KhaoPiyoManagement_System.ILibrary
{
    public class SalesRegisterImp : ISalesRegister
    {
        Entities entities;
        DateTime dtFrom;
        DateTime dtTo;
        DBConnect dbConnect;
        private string query;
        private DataSet ds;
        private string error;
        private List<Cust_View_Tran> trans;

        private List<Billing_Master> billing_master;
        private List<Table_Master> tab_m;

        public SalesRegisterImp()
        {

            entities = new Entities();
            dtFrom = new DateTime();
            dtTo = new DateTime();
            dbConnect = new DBConnect();
        }

       

        MyResponse ISalesRegister.GetTransaction(string from, string to, string filterValue, int ibus_cd, int icomp_cd)
        {
            MyResponse myResponse = new MyResponse();

            

            query = "select * from Table_Master";

            if (dbConnect.Select(query, out ds, out error))
            {
                tab_m = CommonMethod.ConvertToList<Table_Master>(ds.Tables[0]);
            }

            try
            {

                Log.Write("In Get", "");
                if (dtFrom != null && dtTo != null)
                {
                    List<Billing_Master> _Tran = new List<Billing_Master>();
                    List<Cust_View_Tran> cust_Views = new List<Cust_View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
               


                    
                    

                    switch (filterValue.ToLower())
                    {
                        case "void":

                            query = "select * from Billing_Master as bm inner join Table_Master as tm on bm.iTab_Cd=tm.iTab_Cd where bm.bOpen=0 and bm.bVoid=1 and bNC=0 and bm.iComp_Cd=" + icomp_cd + " and bm.iBus_Cd=" + ibus_cd + " and bm.dBill_Dt >= '" + dtFrom.ToString("yyyy-MM-dd") + "' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "'";
                            trans = new List<Cust_View_Tran>();

                            if (dbConnect.Select(query, out ds, out error))
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    if (item != null)
                                    {
                                        var t = new Cust_View_Tran
                                        {
                                            iBill_No = Convert.ToInt32(item["iBill_No"]),
                                            dBill_Dt = Convert.ToString(item["dBill_Dt"]),
                                            sTab_Nm = item["sTab_Nm"].ToString(),
                                            sGuest_Nm = item["sGuest_Nm"].ToString() != "" ? item["sGuest_Nm"].ToString() : "",
                                            sMobile = item["sMobile"].ToString() == "" ? "" : item["sMobile"].ToString(),
                                            iPax = (int)(Convert.ToInt32(item["iPax"]) == 0 ? 0 : Convert.ToInt32(item["iPax"])),
                                            Amount = Convert.ToInt32(item["TAmt"]),
                                            GSTIN = Convert.ToString(item["GSTIN"]) == "" ? "" : Convert.ToString(item["GSTIN"]),
                                            bDiscount = Convert.ToByte(item["bDiscount"]),
                                            bNC = Convert.ToByte(item["bNC"]),
                                            DisAmt = Convert.ToInt32(item["TDiscountValue"]),
                                            bOpen = Convert.ToByte(item["bOpen"]),
                                            iDonationAmt = Convert.ToDouble(item["bOpen"]),
                                            GSTAmt = Convert.ToDouble(item["TGST"]),
                                            iGrand_Amt = Convert.ToDouble(item["iGrand_Amt"]),
                                            iDonationRemark = Convert.ToString(item["iDonationRemark"]),
                                            iWayOffAmt = Convert.ToDouble(item["iWayOffAmt"]),
                                            iTipAmt = Convert.ToDouble(item["iTipAmt"]),
                                            iTipRemark = Convert.ToString(item["iTipRemark"]),
                                            iWayOffRemark = Convert.ToString(item["iWayOffRemark"]),
                                            NCAmt = Convert.ToDouble(item["NCAmt"]),
                                            sBillType = Convert.ToString(item["sBillType"]),
                                            bVoid = Convert.ToByte(item["bVoid"]),
                                            Qty = Convert.ToInt32(item["TQty"]),
                                            sDis_Type = Convert.ToString(item["sDis_Type"]),
                                            sNCReason = Convert.ToString(item["sNCReason"]),
                                            sType = Convert.ToString(item["sType"]),
                                            TAmt = Convert.ToDouble(item["TAmt"]),
                                            sVoidReason = Convert.ToString(item["sVoidReason"]),
                                            TRoundOff = Convert.ToDouble(item["TRoundOff"]),
                                        };

                                        trans.Add(t);
                                    }
                                }
                            }
                            //_Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd && x.bVoid == 1).Distinct().ToList();

                            // trans = billing_master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd && x.bVoid == 1).Join(tab_m, t1 => t1.iTab_Cd, t2 => t2.iTab_Cd, (t1, t2) => new
                            //{
                            //    iBill_No = t1.iBill_No,
                            //   dBill_Dt = SqlFunctions.DateName("year", t1.dBill_Dt) + SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.Replicate("0", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart() + SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.Replicate("0", 2 - SqlFunctions.DateName("dd", t1.dBill_Dt).Trim().Length) + SqlFunctions.DateName("dd", t1.dBill_Dt).Trim(),
                            //   sTab_Nm = t2.sTab_Nm,
                            //    sGuest_Nm = t1.sGuest_Nm != "" ? t1.sGuest_Nm : "",
                            //    sMobile = t1.sMobile == "" ? "" : t1.sMobile,
                            //    iPax = (int)(t1.iPax == 0 || t1.iPax == null ? 0 : t1.iPax),
                            //    GSTIN = t1.GSTIN == "" ? "" : t1.GSTIN,
                            //    Amount = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    bDiscount = (int)t1.bDiscount,
                            //    bNC = (int)t1.bNC,
                            //    DisAmt = (double) (t1.TDiscountValue == 0 || t1.TDiscountValue == null ? 0 : t1.TDiscountValue),
                            //    bOpen = (int)t1.bOpen,
                            //    iDonationAmt = (double)(t1.iDonationAmt == 0 || t1.iDonationAmt == null ? 0 : t1.iDonationAmt),
                            //    GSTAmt = (double)(t1.TGST == 0 || t1.TGST == null ? 0 : t1.TGST),
                            //    iGrand_Amt = (double)(t1.iGrand_Amt == 0 || t1.iGrand_Amt == null ? 0 : t1.iGrand_Amt),
                            //    iDonationRemark = t1.iDonationRemark == "" || t1.iDonationRemark == null ? "" : t1.iDonationRemark,
                            //    iWayOffAmt = (double)(t1.iWayOffAmt == 0 || t1.iWayOffAmt == null ? 0 : t1.iWayOffAmt),
                            //    iTipAmt = (double)(t1.iTipAmt == 0 || t1.iTipAmt == null ? 0 : t1.iTipAmt),
                            //    iTipRemark = t1.iTipRemark == "" || t1.iTipRemark == null ? "" : t1.iTipRemark,
                            //    iWayOffRemark = t1.iWayOffRemark == "" || t1.iWayOffRemark == null ? "" : t1.iWayOffRemark,
                            //    NCAmt = (double)(t1.NCAmt == 0 || t1.NCAmt == null ? 0 : t1.NCAmt),
                            //    sBillType = t1.sBillType == "" || t1.sBillType == null ? "" : t1.sBillType,
                            //    bVoid = (int)t1.bVoid,
                            //    Qty = (double)(t1.TQty == 0 || t1.TQty == null ? 0 : t1.TQty),
                            //    sDis_Type = t1.sDis_Type == "" || t1.sDis_Type == null ? "" : t1.sDis_Type,
                            //    sNCReason = t1.sNCReason == "" || t1.sNCReason == null ? "" : t1.sNCReason,
                            //    sType = t1.sType == "" || t1.sType == null ? "" : t1.sType,
                            //    TAmt = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    sVoidReason = t1.sVoidReason == "" || t1.sVoidReason == null ? "" : t1.sVoidReason,
                            //    TRoundOff = (double)(t1.TRoundOff == 0 || t1.TRoundOff == null ? 0 : t1.TRoundOff),
                            //}).ToList();

                            myResponse.Error = "";
                            myResponse.isValid = true;
                            myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
                            break;
                        case "all":

                            query = "select * from Billing_Master as bm inner join Table_Master as tm on bm.iTab_Cd=tm.iTab_Cd where bm.bOpen=0 and bm.bVoid=0 and bm.iComp_Cd=" + icomp_cd + " and bm.iBus_Cd=" + ibus_cd + " and bm.dBill_Dt >= '"+dtFrom.ToString("yyyy-MM-dd")+"' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "'";
                            trans = new List<Cust_View_Tran>();

                            if (dbConnect.Select(query, out ds, out error))
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    if (item != null)
                                    {
                                        var t = new Cust_View_Tran
                                        {
                                            iBill_No = Convert.ToInt32(item["iBill_No"]),
                                            dBill_Dt = Convert.ToString(item["dBill_Dt"]),
                                            sTab_Nm = item["sTab_Nm"].ToString(),
                                            sGuest_Nm = item["sGuest_Nm"].ToString() != "" ? item["sGuest_Nm"].ToString() : "",
                                            sMobile = item["sMobile"].ToString() == "" ? "" : item["sMobile"].ToString(),
                                            iPax = (int)(Convert.ToInt32(item["iPax"]) == 0 ? 0 : Convert.ToInt32(item["iPax"])),
                                            Amount = Convert.ToInt32(item["TAmt"]),
                                            GSTIN = Convert.ToString(item["GSTIN"]) == "" ? "" : Convert.ToString(item["GSTIN"]),
                                            bDiscount = Convert.ToByte(item["bDiscount"]),
                                            bNC = Convert.ToByte(item["bNC"]),
                                            DisAmt = Convert.ToInt32(item["TDiscountValue"]),
                                            bOpen = Convert.ToByte(item["bOpen"]),
                                            iDonationAmt = Convert.ToDouble(item["bOpen"]),
                                            GSTAmt = Convert.ToDouble(item["TGST"]),
                                            iGrand_Amt = Convert.ToDouble(item["iGrand_Amt"]),
                                            iDonationRemark = Convert.ToString(item["iDonationRemark"]),
                                            iWayOffAmt = Convert.ToDouble(item["iWayOffAmt"]),
                                            iTipAmt = Convert.ToDouble(item["iTipAmt"]),
                                            iTipRemark = Convert.ToString(item["iTipRemark"]),
                                            iWayOffRemark = Convert.ToString(item["iWayOffRemark"]),
                                            NCAmt = Convert.ToDouble(item["NCAmt"]),
                                            sBillType = Convert.ToString(item["sBillType"]),
                                            bVoid = Convert.ToByte(item["bVoid"]),
                                            Qty = Convert.ToInt32(item["TQty"]),
                                            sDis_Type = Convert.ToString(item["sDis_Type"]),
                                            sNCReason = Convert.ToString(item["sNCReason"]),
                                            sType = Convert.ToString(item["sType"]),
                                            TAmt = Convert.ToDouble(item["TAmt"]),
                                            sVoidReason = Convert.ToString(item["sVoidReason"]),
                                            TRoundOff = Convert.ToDouble(item["TRoundOff"]),
                                        };

                                        trans.Add(t);
                                    }
                                }
                            }
                            //_Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd && x.bVoid == 0).Distinct().ToList();
                            //trans = billing_master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd && x.bVoid == 0).Join(tab_m, t1 => t1.iTab_Cd, t2 => t2.iTab_Cd, (t1, t2) => new
                            //{
                            //    iBill_No = t1.iBill_No,
                            //     dBill_Dt = SqlFunctions.Replicate("0", 2 - SqlFunctions.DateName("dd", t1.dBill_Dt).Trim().Length) + SqlFunctions.DateName("dd", t1.dBill_Dt).Trim() + SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.Replicate("0", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart() + SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.DateName("year", t1.dBill_Dt),
                            //     sTab_Nm = t2.sTab_Nm,
                            //    sGuest_Nm = t1.sGuest_Nm != "" ? t1.sGuest_Nm : "",
                            //    sMobile = t1.sMobile == "" ? "" : t1.sMobile,
                            //    iPax = (int)(t1.iPax == 0 || t1.iPax == null ? 0 : t1.iPax),
                            //    GSTIN = t1.GSTIN == "" ? "" : t1.GSTIN,
                            //    Amount = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    bDiscount = (int)t1.bDiscount,
                            //    bNC = (int)t1.bNC,
                            //    DisAmt = (double)(t1.TDiscount == 0 || t1.TDiscount == null ? 0 : t1.TDiscount),
                            //    bOpen = (int)t1.bOpen,
                            //    iDonationAmt = (double)(t1.iDonationAmt == 0 || t1.iDonationAmt == null ? 0 : t1.iDonationAmt),
                            //    GSTAmt = (double)(t1.TGST == 0 || t1.TGST == null ? 0 : t1.TGST),
                            //    iGrand_Amt = (double)(t1.iGrand_Amt == 0 || t1.iGrand_Amt == null ? 0 : t1.iGrand_Amt),
                            //    iDonationRemark = t1.iDonationRemark == "" || t1.iDonationRemark == null ? "" : t1.iDonationRemark,
                            //    iWayOffAmt = (double)(t1.iWayOffAmt == 0 || t1.iWayOffAmt == null ? 0 : t1.iWayOffAmt),
                            //    iTipAmt = (double)(t1.iTipAmt == 0 || t1.iTipAmt == null ? 0 : t1.iTipAmt),
                            //    iTipRemark = t1.iTipRemark == "" || t1.iTipRemark == null ? "" : t1.iTipRemark,
                            //    iWayOffRemark = t1.iWayOffRemark == "" || t1.iWayOffRemark == null ? "" : t1.iWayOffRemark,
                            //    NCAmt = (double)(t1.NCAmt == 0 || t1.NCAmt == null ? 0 : t1.NCAmt),
                            //    sBillType = t1.sBillType == "" || t1.sBillType == null ? "" : t1.sBillType,
                            //    bVoid = (int)t1.bVoid,
                            //    Qty = (double)(t1.TQty == 0 || t1.TQty == null ? 0 : t1.TQty),
                            //    sDis_Type = t1.sDis_Type == "" || t1.sDis_Type == null ? "" : t1.sDis_Type,
                            //    sNCReason = t1.sNCReason == "" || t1.sNCReason == null ? "" : t1.sNCReason,
                            //    sType = t1.sType == "" || t1.sType == null ? "" : t1.sType,
                            //    TAmt = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    sVoidReason = t1.sVoidReason == "" || t1.sVoidReason == null ? "" : t1.sVoidReason,
                            //    TRoundOff = (double)(t1.TRoundOff == 0 || t1.TRoundOff == null ? 0 : t1.TRoundOff),
                            //}).ToList();

                            myResponse.Error = "";
                            myResponse.isValid = true;
                            myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);

                            break;
                        case "nc":

                            query = "select * from Billing_Master as bm inner join Table_Master as tm on bm.iTab_Cd=tm.iTab_Cd where bm.bOpen=0 and bm.bVoid=0 and bm.bNC=1 and bm.iComp_Cd=" + icomp_cd + " and bm.iBus_Cd=" + ibus_cd + " and bm.dBill_Dt >= '" + dtFrom.ToString("yyyy-MM-dd") + "' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "'";
                            trans = new List<Cust_View_Tran>();

                            if (dbConnect.Select(query, out ds, out error))
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    if (item != null)
                                    {
                                        var t = new Cust_View_Tran
                                        {
                                            iBill_No = Convert.ToInt32(item["iBill_No"]),
                                            dBill_Dt = Convert.ToString(item["dBill_Dt"]),
                                            sTab_Nm = item["sTab_Nm"].ToString(),
                                            sGuest_Nm = item["sGuest_Nm"].ToString() != "" ? item["sGuest_Nm"].ToString() : "",
                                            sMobile = item["sMobile"].ToString() == "" ? "" : item["sMobile"].ToString(),
                                            iPax = (int)(Convert.ToInt32(item["iPax"]) == 0 ? 0 : Convert.ToInt32(item["iPax"])),
                                            Amount = Convert.ToInt32(item["TAmt"]),
                                            GSTIN = Convert.ToString(item["GSTIN"]) == "" ? "" : Convert.ToString(item["GSTIN"]),
                                            bDiscount = Convert.ToByte(item["bDiscount"]),
                                            bNC = Convert.ToByte(item["bNC"]),
                                            DisAmt = Convert.ToInt32(item["TDiscountValue"]),
                                            bOpen = Convert.ToByte(item["bOpen"]),
                                            iDonationAmt = Convert.ToDouble(item["bOpen"]),
                                            GSTAmt = Convert.ToDouble(item["TGST"]),
                                            iGrand_Amt = Convert.ToDouble(item["iGrand_Amt"]),
                                            iDonationRemark = Convert.ToString(item["iDonationRemark"]),
                                            iWayOffAmt = Convert.ToDouble(item["iWayOffAmt"]),
                                            iTipAmt = Convert.ToDouble(item["iTipAmt"]),
                                            iTipRemark = Convert.ToString(item["iTipRemark"]),
                                            iWayOffRemark = Convert.ToString(item["iWayOffRemark"]),
                                            NCAmt = Convert.ToDouble(item["NCAmt"]),
                                            sBillType = Convert.ToString(item["sBillType"]),
                                            bVoid = Convert.ToByte(item["bVoid"]),
                                            Qty = Convert.ToInt32(item["TQty"]),
                                            sDis_Type = Convert.ToString(item["sDis_Type"]),
                                            sNCReason = Convert.ToString(item["sNCReason"]),
                                            sType = Convert.ToString(item["sType"]),
                                            TAmt = Convert.ToDouble(item["TAmt"]),
                                            sVoidReason = Convert.ToString(item["sVoidReason"]),
                                            TRoundOff = Convert.ToDouble(item["TRoundOff"]),
                                        };

                                        trans.Add(t);
                                    }
                                }
                            }

                            //trans = billing_master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd && x.bVoid == 0 &&x.bNC==1).Join(tab_m, t1 => t1.iTab_Cd, t2 => t2.iTab_Cd, (t1, t2) => new
                            //{
                            //    iBill_No = t1.iBill_No,
                            //    dBill_Dt = SqlFunctions.Replicate("0", 2 - SqlFunctions.DateName("dd", t1.dBill_Dt).Trim().Length) + SqlFunctions.DateName("dd", t1.dBill_Dt).Trim()+SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.Replicate("0", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart() + SqlFunctions.Replicate("/", 2 - SqlFunctions.StringConvert((double)t1.dBill_Dt.Value.Month).TrimStart().Length) + SqlFunctions.DateName("year", t1.dBill_Dt),
                            //    sTab_Nm = t2.sTab_Nm,
                            //    sGuest_Nm = t1.sGuest_Nm != "" ? t1.sGuest_Nm : "",
                            //    sMobile = t1.sMobile == "" ? "" : t1.sMobile,
                            //    iPax = (int)(t1.iPax == 0 || t1.iPax == null ? 0 : t1.iPax),
                            //    GSTIN = t1.GSTIN == "" ? "" : t1.GSTIN,
                            //    Amount = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    bDiscount = (int)t1.bDiscount,
                            //    bNC = (int)t1.bNC,
                            //    DisAmt = (double)(t1.TDiscountValue == 0 || t1.TDiscountValue == null ? 0 : t1.TDiscountValue),
                            //    bOpen = (int)t1.bOpen,
                            //    iDonationAmt = (double)(t1.iDonationAmt == 0 || t1.iDonationAmt == null ? 0 : t1.iDonationAmt),
                            //    GSTAmt = (double)(t1.TGST == 0 || t1.TGST == null ? 0 : t1.TGST),
                            //    iGrand_Amt = (double)(t1.iGrand_Amt == 0 || t1.iGrand_Amt == null ? 0 : t1.iGrand_Amt),
                            //    iDonationRemark = t1.iDonationRemark == "" || t1.iDonationRemark == null ? "" : t1.iDonationRemark,
                            //    iWayOffAmt = (double)(t1.iWayOffAmt == 0 || t1.iWayOffAmt == null ? 0 : t1.iWayOffAmt),
                            //    iTipAmt = (double)(t1.iTipAmt == 0 || t1.iTipAmt == null ? 0 : t1.iTipAmt),
                            //    iTipRemark = t1.iTipRemark == "" || t1.iTipRemark == null ? "" : t1.iTipRemark,
                            //    iWayOffRemark = t1.iWayOffRemark == "" || t1.iWayOffRemark == null ? "" : t1.iWayOffRemark,
                            //    NCAmt = (double)(t1.NCAmt == 0 || t1.NCAmt == null ? 0 : t1.NCAmt),
                            //    sBillType = t1.sBillType == "" || t1.sBillType == null ? "" : t1.sBillType,
                            //    bVoid = (int)t1.bVoid,
                            //    Qty = (double)(t1.TQty == 0 || t1.TQty == null ? 0 : t1.TQty),
                            //    sDis_Type = t1.sDis_Type == "" || t1.sDis_Type == null ? "" : t1.sDis_Type,
                            //    sNCReason = t1.sNCReason == "" || t1.sNCReason == null ? "" : t1.sNCReason,
                            //    sType = t1.sType == "" || t1.sType == null ? "" : t1.sType,
                            //    TAmt = (double)(t1.TAmt == 0 || t1.TAmt == null ? 0 : t1.TAmt),
                            //    sVoidReason = t1.sVoidReason == "" || t1.sVoidReason == null ? "" : t1.sVoidReason,
                            //    TRoundOff = (double)(t1.TRoundOff == 0 || t1.TRoundOff == null ? 0 : t1.TRoundOff),
                            //}).ToList();

                            myResponse.Error = "";
                            myResponse.isValid = true;
                            myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
                            break;
                        default:
                            break;
                    }



                    //_Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen==0&&x.iBus_Cd==1&&x.iComp_Cd==1).Distinct().ToList();

                    //foreach (var item in _Tran)
                    //{
                    //    foreach (var tabM in tab_m)
                    //    {

                    //        if (tabM.iTab_Cd == item.iTab_Cd) {
                    //            cust_Views.Add(new Cust_View_Tran
                    //            {

                    //                iBill_No = item.iBill_No,
                    //                dBill_Dt = item.dBill_Dt.Value.ToString("dd-MM-yyyy"),
                    //                sTab_Nm = tabM.sTab_Nm,
                    //                sGuest_Nm = item.sGuest_Nm==""?"": item.sGuest_Nm,
                    //                sMobile = item.sMobile == "" ? "" : item.sMobile,
                    //                iPax = (int)(item.iPax == 0||item.iPax== null ? 0 : item.iPax),
                    //                GSTIN = item.GSTIN == "" ? "" : item.GSTIN,
                    //                Amount = (double)(item.TAmt == 0||item.TAmt==null ? 0 : item.TAmt),
                    //                bDiscount = (int)item.bDiscount,
                    //                bNC = (int)item.bNC,
                    //                DisAmt = (double)(item.TDiscountValue == 0|| item.TDiscountValue == null ?0 :item.TDiscountValue) ,
                    //                bOpen = (int)item.bOpen,
                    //                iDonationAmt = (double)(item.iDonationAmt==0||item.iDonationAmt==null?0:item.iDonationAmt),
                    //                GSTAmt =(double) (item.TGST== 0 || item.TGST == null ? 0 : item.TGST),
                    //                iGrand_Amt = (double)(item.iGrand_Amt == 0 || item.iGrand_Amt == null ? 0 : item.iGrand_Amt),
                    //                iDonationRemark = item.iDonationRemark == "" || item.iDonationRemark == null ? "" : item.iDonationRemark,
                    //                iWayOffAmt = (double)(item.iWayOffAmt == 0 || item.iWayOffAmt == null ? 0 : item.iWayOffAmt),
                    //                iTipAmt = (double)(item.iTipAmt == 0 || item.iTipAmt == null ? 0 : item.iTipAmt),
                    //                iTipRemark = item.iTipRemark == "" || item.iTipRemark == null ? "" : item.iTipRemark,
                    //                iWayOffRemark = item.iWayOffRemark == "" || item.iWayOffRemark == null ? "" : item.iWayOffRemark,
                    //                NCAmt = (double)(item.NCAmt == 0 || item.NCAmt == null ? 0 : item.NCAmt),
                    //                sBillType = item.sBillType == "" || item.sBillType == null ? "" : item.sBillType,
                    //                bVoid = (int)item.bVoid,
                    //                Qty = (double)(item.TQty == 0 || item.TQty == null ? 0 : item.TQty),
                    //                sDis_Type = item.sDis_Type == "" || item.sDis_Type == null ? "" : item.sDis_Type,
                    //                sNCReason = item.sNCReason == "" || item.sNCReason == null ? "" : item.sNCReason,
                    //                sType = item.sType == "" || item.sType == null ? "" : item.sType,
                    //                TAmt = (double)(item.TAmt == 0 || item.TAmt == null ? 0 : item.TAmt),
                    //                sVoidReason = item.sVoidReason == "" || item.sVoidReason == null ? "" : item.sVoidReason,
                    //                TRoundOff = (double)(item.TRoundOff == 0 || item.TRoundOff == null ? 0 : item.TRoundOff),
                    //            });
                    //        }
                    //    }
                    //}

                    //myResponse.Error = "";
                    //myResponse.isValid = true;
                    //myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(cust_Views);
                }
                else
                {
                    myResponse.Error = "Invalid datetime or empty";
                    myResponse.isValid = false;
                    myResponse.JsonStr = null;
                }

            }
            catch (Exception EX)
            {
                myResponse.Error = EX.Message;
                myResponse.isValid = false;
                myResponse.JsonStr = null;
                throw EX;
            }
            finally
            {

            }
            return myResponse;
        }
    }


}

namespace System
{
    public class MyResponse
    {
        public string Error { get; set; }
        public bool isValid { get; set; }
        public string JsonStr { get; set; }
    }
}