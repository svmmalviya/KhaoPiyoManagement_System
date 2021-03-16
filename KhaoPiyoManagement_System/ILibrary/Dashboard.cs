﻿using System;
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
    public class Dashboard : IDashboard
    {
        KhaoPiyoEntities entities;
        DateTime dtFrom;
        DateTime dtTo;

        public Dashboard()
        {
            entities = new KhaoPiyoEntities();
            dtFrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtTo = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public MyResponse GetCompanyDetails(int? iuser_cd)
        {
            MyResponse myResponse = new MyResponse();
            try
            {
                if (dtFrom != null && dtTo != null)
                {
                    List<ItemSummary> retrivedData = new List<ItemSummary>();
                    List<View_Tran> cust_Views = new List<View_Tran>();


                    var compDetail = entities.Company_Master.Where(x => x.iUser_Cd.Value == iuser_cd).FirstOrDefault();


                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(compDetail);
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

        public List<object> GetDailyMoneyCollection(int ibus_cd, int icomp_cd)
        {
            try
            {
                var todayDT = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                DBConnect db = new DBConnect();
                DataSet ds = new DataSet();
                string StrError = "";
                List<object> iData = new List<object>();
                // string[] aData = new string[2]; 


                //var query = "select sum(bm.TAmt) as TotAmt,bp.sType as sPay_Nm from Billing_Master as bm inner join Billing_Payment as bp on bm.iBill_No=bp.iBill_No where (dBill_Dt>='" + todayDT.ToString() + "' and dBill_Dt <= '" + todayDT.ToString() + "') AND(bm.iComp_Cd = 1) AND(bm.iBus_Cd = 1) AND(bm.bOpen = 0) AND(bm.bVoid = 0) AND(bm.bNC = 0)  group by bp.sType";
                var query = "SELECT  SUM(Billing_Payment.iPay_Amount) AS Tot,PayMode_Master.sPay_Nm " +
"FROM Billing_Payment INNER JOIN PayMode_Master ON Billing_Payment.iComp_Cd = PayMode_Master.iComp_Cd AND Billing_Payment.iBus_Cd = PayMode_Master.iBus_Cd AND Billing_Payment.iType = PayMode_Master.iPay_Cd INNER JOIN"+
                 " Billing_Master ON Billing_Payment.iBill_No = Billing_Master.iBill_No AND Billing_Payment.iComp_Cd = Billing_Master.iComp_Cd AND Billing_Payment.iBus_Cd = Billing_Master.iBus_Cd "+
" WHERE(Billing_Master.bVoid = 0) AND(Billing_Master.bOpen = 0) AND(Billing_Master.dBill_Dt >= '"+todayDT.ToString()+"') AND(Billing_Master.dBill_Dt <= '"+ todayDT.ToString() + "') "+
" GROUP BY PayMode_Master.sPay_Nm ORDER BY PayMode_Master.sPay_Nm";


                if (db.Select(query, out ds, out StrError))
                {
                    if (ds != null)
                    {
                        foreach (DataColumn dc in ds.Tables[0].Columns)
                        {
                            List<object> x = new List<object>();
                            x = (from DataRow drr in ds.Tables[0].Rows select drr[dc.ColumnName]).ToList();
                            iData.Add(x);
                        }
                    }
                }
                return iData;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public MyResponse GetDashboardSummary(string from, string to,int icomp_cd,int ibus_cd)
        {
            MyResponse myResponse = new MyResponse();
            var todayDT = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            DBConnect db = new DBConnect();
            DataSet ds = new DataSet();
            string StrError = "";
            List<string> iLabels = new List<string>();
            List<string> iData = new List<string>();

            try
            {
                if (dtFrom != null && dtTo != null)
                {
                    List<View_Tran> cust_Views = new List<View_Tran>();
                    DashboardSummary dashboardSummary = new DashboardSummary();


                    dtFrom = DateTime.ParseExact(from, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    dtTo = DateTime.ParseExact(to, GlobalProperties.Instance.dateformate, System.Globalization.CultureInfo.InvariantCulture);
                    //cust_Views = entities.View_Tran.Where(x => x.dBill_Dt >= this.dtFrom && x.dBill_Dt <= this.dtTo && x.iBus_Cd == 1 && x.iComp_Cd == 1 && x.bOpen == 0 && x.bVoid == 0).ToList();

                    dashboardSummary.billcount = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo &&x.bVoid==0 &&x.iComp_Cd==icomp_cd&&x.iBus_Cd==ibus_cd&&x.bNC==0).Select(x => x.iBill_No).Count().ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString();
                    dashboardSummary.guest =     entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString()==""?"0": entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString();
                    dashboardSummary.sale =      entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString();
                    dashboardSummary.expences =  entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString() == "" ? "0" : entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo &&x.iComp_Cd==icomp_cd&&x.iBus_Cd==ibus_cd).Sum(x => x.iAmount).ToString();

                    var dt=  entities.Billing_Master.Join(entities.Billing_Payment,
                        tm => new { tm.iBill_No,tm.iFin_Cd,tm.iBus_Cd,tm.iComp_Cd },
                        pm => new { pm.iBill_No,pm.iFin_Cd,pm.iBus_Cd,pm.iComp_Cd },
                        (tm, pm) => new { tm.iGrand_Amt,pm.sType }).GroupBy(x=>x.sType);


                    
                    string query = "SELECT  SUM(Billing_Payment.iPay_Amount) AS TotAmt,PayMode_Master.sPay_Nm " +
            "FROM Billing_Payment INNER JOIN PayMode_Master ON Billing_Payment.iComp_Cd = PayMode_Master.iComp_Cd AND Billing_Payment.iBus_Cd = PayMode_Master.iBus_Cd AND Billing_Payment.iType = PayMode_Master.iPay_Cd INNER JOIN" +
                 " Billing_Master ON Billing_Payment.iBill_No = Billing_Master.iBill_No AND Billing_Payment.iComp_Cd = Billing_Master.iComp_Cd AND Billing_Payment.iBus_Cd = Billing_Master.iBus_Cd " +
            " WHERE(Billing_Master.bVoid = 0) AND(Billing_Master.bOpen = 0) AND(Billing_Master.dBill_Dt >= '" + dtFrom.ToString("MM/dd/yyyy") + "') AND(Billing_Master.dBill_Dt <= '" + dtTo.ToString("MM/dd/yyyy") + "') " +
            " GROUP BY PayMode_Master.sPay_Nm ORDER BY PayMode_Master.sPay_Nm";


                    if (db.Select(query, out ds, out StrError))
                    {
                        if (ds != null)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                iLabels.Add(row["sPay_Nm"].ToString());
                                iData.Add(row["TotAmt"].ToString());
                            }
                        }
                    }

                    dashboardSummary.chartData = iData;
                    dashboardSummary.chartLabels = iLabels;

                    myResponse.Error = "";
                    myResponse.isValid = true;
                    myResponse.JsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dashboardSummary);
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

        public string GetTodaysTotalBill(int ibus_cd, int icomp_cd)
        {
            var todayTotalBills = "0";

            try
            {
                //entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString();
                //entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString();
                //entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString();
                //entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString() == "" ? "0" : entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString();
                //todayTotalBills = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.iBus_Cd == ibus_cd && x.iComp_Cd == icomp_cd &&x.bVoid==0).Select(x => x.iBill_No).Count().ToString();
                todayTotalBills = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalBills == "" ? "0" : todayTotalBills;
        }

        public string GetTodaysTotalExpenses(int ibus_cd, int icomp_cd)
        {
            var todayTotalExp = "0";

            try
            {
                todayTotalExp = entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString() == "" ? "0" : entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalExp == "" ? "0" : todayTotalExp;
        }

        public string GetTodaysTotalGuest(int ibus_cd, int icomp_cd)
        {
            var todayTotalGuest = "0";
            try
            {
                todayTotalGuest = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalGuest == "" ? "0" : todayTotalGuest;
        }

        public string GetTodaysTotalSales(int ibus_cd, int icomp_cd)
        {
            var todayTotalSales = "0";
            try
            {
                todayTotalSales = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalSales == "" ? "0" : todayTotalSales;
        }
    }
}