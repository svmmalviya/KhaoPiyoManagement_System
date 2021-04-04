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
        Entities entities;
        DateTime dtFrom;
        DateTime dtTo;
        MyResponse myResponse;
        private string query;
        private List<ItemSummary> trans;
        private DataSet ds;
        private DBConnect dbConnect;
        private string error;

        public ItemSummaryImp()
        {
            entities = new Entities();
            dbConnect = new DBConnect();
            trans = new List<ItemSummary>();
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

                    query = "select * from KOT_Delete kotd inner join Item_Master as im on kotd.iItem_Cd=im.iItem_Cd where  kotd.UpdateDate >= '"+dtFrom+"' and kotd.UpdateDate<='" + dtTo+"' ";

                    trans = new List<ItemSummary>();

                    if (dbConnect.Select(query, out ds, out error))
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            if (item != null)
                            {
                                auditReports.Add(new AuditReport
                                {
                                    sItem_Nm = item["sItem_Nm"].ToString(),
                                    date = item["UpdateDate"].ToString().Split(' ')[0].ToString(),
                                    time = item["UpdateDate"].ToString().Split(' ')[1].ToString(),
                                    iBill_No = Convert.ToInt32(item["iBill_No"].ToString()),
                                    UserName = item["UserName"].ToString(),
                                    TAmt = (Convert.ToDouble(item["Rate"])*Convert.ToDouble(item["Qty"])),
                                    Rate = Convert.ToDouble(item["Rate"]),
                                    Qty = Convert.ToInt32(item["Qty"]),
                                });
                            }
                        }
                    }

                    //var r = from t1 in entities.KOT_Delete
                    //        join t2 in entities.Item_Master on t1.iItem_Cd equals t2.iItem_Cd where t1.UpdateDate>=dtFrom && t1.UpdateDate<=dtTo
                    //        select new { sItem_Nm = t2.sItem_Nm, UserName = t1.UserName, UpdateDate = t1.UpdateDate, Qty = t1.Qty, Rate = t1.Rate, iBill_No = t1.iBill_No, TAmt = (double)(t1.Rate * t1.Qty)};

                    //foreach (var item in r)
                    //{
                    //        auditReports.Add(new AuditReport
                    //        {
                    //            sItem_Nm = item.sItem_Nm,
                    //            date = item.UpdateDate.Value.ToString().Split(' ')[0].ToString(),
                    //            time = item.UpdateDate.Value.ToString().Split(' ')[1].ToString(),
                    //            iBill_No = (int)item.iBill_No,
                    //            UserName = item.UserName,
                    //            TAmt = (double)item.TAmt,
                    //            Rate = (double)item.Rate,
                    //            Qty = (int)item.Qty,
                    //        });
                    //}
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

                    query = "select sum(bm.Amount) as TAmt,sum(bm.DisAmt) as TDisAmt, sum(bm.Qty) as TQty,sum(bm.TaxAmt) as TTax, bm.sCat_Nm as item,sum(bm.Total) as total  from View_tran as bm where bm.bOpen=0 and bm.bVoid=0 and bm.bNC=0 and bm.iComp_Cd=1 and bm.iBus_Cd=1 and bm.dBill_Dt >= '" + dtFrom.ToString("yyyy-MM-dd") + "' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "' group by bm.sCat_Nm";
                    trans = new List<ItemSummary>();

                    if (dbConnect.Select(query, out ds, out error))
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            if (item != null)
                            {
                                var t = new ItemSummary
                                {
                                    TAmt = Convert.ToDouble(item["TAmt"]),
                                    TDisAmt = Convert.ToDouble(item["TDisAmt"]),
                                    TQty = Convert.ToDouble(item["TQty"]),
                                    TTax = Convert.ToDouble(item["TTax"]),
                                    item = Convert.ToString(item["item"]),
                                    total = Convert.ToDouble(item["total"])
                                };

                                trans.Add(t);
                            }
                        }
                    }


                    //cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();

                    //var result = cust_Views.GroupBy(x => x.sCat_Nm).Select(x => new
                    //{
                    //    TAmt = (double)x.Sum(k => k.Amount),
                    //    TDisAmt = (double)x.Sum(k => k.DisAmt),
                    //    TQty = (int)x.Sum(k => k.Qty),
                    //    TTax = (double)x.Sum(k => k.TaxAmt),
                    //    item = x.Select(k => k.sCat_Nm).First(),
                    //    total = (double)x.Sum(k => k.Total)
                    //}).ToList();


                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
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
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);



                    query = "select sum(bm.Amount) as TAmt,sum(bm.DisAmt) as TDisAmt, sum(bm.Qty) as TQty,sum(bm.TaxAmt) as TTax, bm.sMeal_Nm as item,sum(bm.Total) as total  from View_tran as bm where bm.bOpen=0 and bm.bVoid=0 and bm.bNC=0 and bm.iComp_Cd=1 and bm.iBus_Cd=1 and bm.dBill_Dt >= '" + dtFrom.ToString("yyyy-MM-dd") + "' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "' group by bm.sMeal_Nm";
                   

                    if (dbConnect.Select(query, out ds, out error))
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            if (item != null)
                            {
                                var t = new ItemSummary
                                {
                                    TAmt = Convert.ToDouble(item["TAmt"]),
                                    TDisAmt = Convert.ToDouble(item["TDisAmt"]),
                                    TQty = Convert.ToDouble(item["TQty"]),
                                    TTax = Convert.ToDouble(item["TTax"]),
                                    item = Convert.ToString(item["item"]),
                                    total = Convert.ToDouble(item["total"])
                                };

                                trans.Add(t);
                            }
                        }
                    }

                    //cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();

                    //var result = cust_Views.GroupBy(x => x.sMeal_Nm).Select(x => new
                    //{
                    //    TAmt = (double)x.Sum(k => k.Amount),
                    //    TDisAmt = (double)x.Sum(k => k.DisAmt),
                    //    TQty = (int)x.Sum(k => k.Qty),
                    //    TTax = (double)x.Sum(k => k.TaxAmt),
                    //    item = x.Select(k => k.sMeal_Nm).First(),
                    //    total = (double)x.Sum(k => k.Total)
                    //}).ToList();
                    
                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
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
                trans = new List<ItemSummary>();
                
                if (dtFrom != null && dtTo != null)
                {
                    List<ItemSummary> retrivedData = new List<ItemSummary>();
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    Log.Write(from, "");
                    Log.Write(to, "");
                    //dtFrom = DateTime.Parse(from);
                    //dtTo = DateTime.Parse(to);

                    query = "select sum(bm.Amount) as TAmt,sum(bm.DisAmt) as TDisAmt, sum(bm.Qty) as TQty,sum(bm.TaxAmt) as TTax, bm.sItem_Nm as item,sum(bm.Total) as total  from View_tran as bm where bm.bOpen=0 and bm.bVoid=0 and bm.bNC=0 and bm.iComp_Cd=1 and bm.iBus_Cd=1 and bm.dBill_Dt >= '" + dtFrom.ToString("yyyy-MM-dd") + "' and bm.dBill_Dt<='" + dtTo.ToString("yyyy-MM-dd") + "' group by bm.sItem_Nm";
                    trans = new List<ItemSummary>();

                    if (dbConnect.Select(query, out ds, out error))
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            if (item != null)
                            {
                                var t = new ItemSummary
                                {
                                    TAmt =  Convert.ToDouble( item["TAmt"]),
                                    TDisAmt = Convert.ToDouble(item["TDisAmt"]),
                                    TQty = Convert.ToDouble(item["TQty"]),
                                    TTax = Convert.ToDouble(item["TTax"]),
                                    item = Convert.ToString(item["item"]),
                                    total = Convert.ToDouble(item["total"])
                                };

                                trans.Add(t);
                            }
                        }
                    }

                    //cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.bOpen == 0 && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bVoid == 0).ToList();


                    //var result = cust_Views.GroupBy(x => x.sItem_Nm).Select(x => new
                    //{
                    //    TAmt = (double)x.Sum(k => k.Amount),
                    //    TDisAmt = (double)x.Sum(k => k.DisAmt),
                    //    TQty = (int)x.Sum(k => k.Qty),
                    //    TTax = (double)x.Sum(k => k.TaxAmt),
                    //    item = x.Select(k => k.sItem_Nm).First(),
                    //    total = (double)x.Sum(k => k.Total)
                    //}).ToList();
                 

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
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