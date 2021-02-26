using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Classes;
using KhaoPiyoManagement_System.Models;
using Microsoft.Ajax.Utilities;

namespace KhaoPiyoManagement_System.ILibrary
{
    public class ItemSummaryImp : IItemSummary
    {
        KhaoPiyoEntities entities;
        DateTime dtFrom;
        DateTime dtTo;
        MyResponse myResponse;

        public ItemSummaryImp() {
            entities = new KhaoPiyoEntities();
        }

        public MyResponse GetTransactionAuditReport(string from, string to)
        {
            Log.Write("In GetAuditReport", "");
            myResponse = new MyResponse();
            try
            {
                if (dtFrom != null && dtTo != null)
                {
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    List<AuditReport> auditReports = new List<AuditReport>();
                    

                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    //cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();

                    var r = from t1 in entities.KOT_Delete
                            join t2 in entities.Item_Master on t1.iItem_Cd equals t2.iItem_Cd 
                            select new { sItem_Nm=t2.sItem_Nm, UserName=t1.UserName, UpdateDate=t1.UpdateDate, Qty=t1.Qty, Rate=t1.Rate, iBill_No=t1.iBill_No,TAmt=(double)(t1.Rate*t1.Qty)};

                    foreach (var item in r)
                    {
                        if (Convert.ToDateTime(item.UpdateDate) > dtFrom.AddDays(-1) && Convert.ToDateTime( item.UpdateDate)<=dtTo) {
                            auditReports.Add(new AuditReport {
                                sItem_Nm=item.sItem_Nm,
                                date=item.UpdateDate.Value.ToString().Split(' ')[0].ToString(),
                                time=item.UpdateDate.Value.ToString().Split(' ')[1].ToString(),
                                iBill_No=(int)item.iBill_No,
                                UserName=item.UserName,
                                TAmt=(double)item.TAmt,
                                Rate= (double)item.Rate,
                                Qty= (int)item.Qty,
                            });
                        }
                    }
                    //var result = r.Where(x => x.UpdateDate >= dtFrom&&x.UpdateDate<=dtTo).ToList();

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(auditReports);
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
                  Log.Write(EX.Message, "");
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

        public MyResponse GetTransactionCatWise(string from, string to)
        {
            Log.Write("Get TransactionCatWise", "");
            MyResponse myResponse = new MyResponse();
            try
            {
                if (dtFrom != null && dtTo != null)
                {
                    List<ItemSummary> retrivedData = new List<ItemSummary>();
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);

                    cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();


                    var result = from p in cust_Views
                                 group p by p.sCat_Nm into g
                                 select new
                                 {
                                     TAmt = (double)g.Sum(x => x.TAmt),
                                     TDisAmt = (double)g.Sum(x => x.DisAmt),
                                     TQty = (int)g.Sum(x => x.TQty),
                                     TTax = (double)g.Sum(x => x.TaxAmt),
                                     item = g.Select(x => x.sCat_Nm).FirstOrDefault()
                                 };

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
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
                Log.Write(EX.Message, "");
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

        public MyResponse GetTransactionMealWise(string from, string to)
        {
            Log.Write("In GetTranMealWise", "");
            MyResponse myResponse = new MyResponse();
            try
            {
                if (dtFrom != null && dtTo != null)
                {
                    List<ItemSummary> retrivedData = new List<ItemSummary>();
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);


                    cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo &&x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();


                    var result = from p in cust_Views
                                 group p by p.sMeal_Nm into g
                                 select new
                                 {
                                     TAmt = (double)g.Sum(x => x.TAmt),
                                     TDisAmt = (double)g.Sum(x => x.DisAmt),
                                     TQty = (int)g.Sum(x => x.TQty),
                                     TTax = (double)g.Sum(x => x.TaxAmt),
                                     item = g.Select(x => x.sMeal_Nm).FirstOrDefault()
                                 };

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
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
                Log.Write(EX.Message, "");
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

        MyResponse IItemSummary.GetTransactionItemWise(string from, string to)
        {
            MyResponse myResponse = new MyResponse();
            try
            {
                Log.Write("In GetTransactionItemWise", "");
                if (dtFrom != null && dtTo != null)
                {
                    List<ItemSummary> retrivedData=new List<ItemSummary>();
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    Log.Write(from,"");
                    Log.Write(to,"");
                    //dtFrom = DateTime.Parse(from);
                    //dtTo = DateTime.Parse(to);

                    cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();


                    var result = from p in cust_Views
                            group p by p.sItem_Nm into g
                            select new
                            {
                                TAmt = (double)g.Sum(x => x.TAmt),
                                TDisAmt = (double)g.Sum(x => x.DisAmt),
                                TQty = (int)g.Sum(x => x.TQty),
                                TTax = (double)g.Sum(x => x.TaxAmt),
                                item = g.Select(x => x.sItem_Nm).FirstOrDefault()
                            };

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
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
                Log.Write(EX.Message, "");
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