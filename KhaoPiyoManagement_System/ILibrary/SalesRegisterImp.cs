using System;
using System.Collections.Generic;
using System.Data;
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
        KhaoPiyoEntities entities;
        DateTime dtFrom;
        DateTime dtTo;


        public SalesRegisterImp()
        {

            entities = new KhaoPiyoEntities();
            dtFrom = new DateTime();
            dtTo = new DateTime();
        }


        MyResponse ISalesRegister.GetTransaction(string from, string to, string filterValue)
        {
            MyResponse myResponse = new MyResponse();
            try
            {

                Log.Write("In Get","");
                if (dtFrom != null && dtTo != null)
                {
                    List<Billing_Master> _Tran = new List<Billing_Master>();
                    List<Cust_View_Tran> cust_Views = new List<Cust_View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);

                    switch (filterValue.ToLower())
                    {
                        case "void":
                            _Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bVoid == 1).Distinct().ToList();
                            break;
                        case "all":
                            _Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == 1 && x.iComp_Cd == 1).Distinct().ToList();
                            break;
                        case "nc":
                            _Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bNC == 1).Distinct().ToList();
                            break;
                        default:
                            break;
                    }


                    //_Tran = entities.Billing_Master.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen==0&&x.iBus_Cd==1&&x.iComp_Cd==1).Distinct().ToList();

                    foreach (var item in _Tran)
                    {
                        cust_Views.Add(new Cust_View_Tran
                        {
                            iBill_No = item.iBill_No,
                            dBill_Dt = item.dBill_Dt.Value.ToString("dd-MM-yyyy"),
                            iTab_Cd = (int)item.iTab_Cd,
                            sGuest_Nm = item.sGuest_Nm,
                            sMobile = item.sMobile,
                            iPax = (int)item.iPax,
                            GSTIN = item.GSTIN,
                            Amount = (int)item.TAmt,
                            bDiscount = (int)item.bDiscount,
                            bNC = (int)item.bNC,
                            DisAmt = (int)item.TDiscountValue,
                            bOpen = (int)item.bOpen,
                            iDonationAmt = item.iDonationAmt,
                            GSTAmt = item.TGST,
                            iGrand_Amt = (double)item.iGrand_Amt,
                            iDonationRemark = item.iDonationRemark,
                            iWayOffAmt = item.iWayOffAmt,
                            iTipAmt = item.iTipAmt,
                            iTipRemark = item.iTipRemark,
                            iWayOffRemark = item.iWayOffRemark,
                            NCAmt = (double)item.NCAmt,
                            sBillType = item.sBillType,
                            bVoid = (int)item.bVoid,
                            Qty = (double)item.TQty,
                            sDis_Type = item.sDis_Type,
                            sNCReason = item.sNCReason,
                            sType = item.sType,
                            TAmt = (double)item.TAmt,
                            sVoidReason = item.sVoidReason,
                        });
                    }

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(cust_Views);
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