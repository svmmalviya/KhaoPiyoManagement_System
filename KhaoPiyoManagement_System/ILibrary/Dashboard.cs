using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhaoPiyoManagement_System.Models;

namespace KhaoPiyoManagement_System.ILibrary
{
    public class Dashboard : IDashboard
    {
        KhaoPiyoEntities entities;
        DateTime dtFrom;
        DateTime dtTo;

        public Dashboard() {
            entities = new KhaoPiyoEntities();
            dtFrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            dtTo = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public List<TableDetails> GetRunningTableDetail(int tablecd)
        {
            List<TableDetails> tableDetails = new List<TableDetails>();
            try
            {
                var trans = entities.View_Tran.ToList();

              

                foreach (var item in trans)
                {
                    if (item.iTab_Cd == tablecd && item.bOpen == 1 && item.iComp_Cd == 1 && item.iBus_Cd == 1)
                    {
                        tableDetails.Add(new TableDetails
                        {
                            cat = item.sTab_Cat_Nm,
                            tabno = item.sTab_Nm,
                            tabno_cd = item.iTab_Cd.ToString(),
                            billno = item.iBill_No.ToString(),
                            billdate = item.dBill_Dt.Value.ToString("dd-MM-yyyy"),
                            guestname = item.sGuest_Nm,
                            mobileno = item.sMobile,
                            pax = item.iPax.ToString(),
                            waiter = item.sAttd_Nm,
                            itemname = item.sItem_Nm,
                            qty = item.Qty.ToString(),
                            rate = item.Rate.ToString(),
                            amount = item.Amount.ToString(),
                            total = item.TAmt.ToString(),
                            discount = item.TDiscount.ToString(),
                            tax = item.TGST.ToString(),
                            roundoff = item.TRoundOff.ToString(),
                            grandtotal = item.iGrand_Amt.ToString(),
                            totqty = item.TQty.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return tableDetails;
        }

        public RunningTables GetRunningTables(int iCompany_Cd,int iBusiness_Cd)
        {
            RunningTables rtabs = new RunningTables();

            try
            {
                var listofrunningtables = entities.View_RunningTable.Where(x => x.iComp_Cd == iCompany_Cd && x.iBus_Cd == iBusiness_Cd);

                List<string> catart = new List<string>();
                List<tableCode> tabary = new List<tableCode>();

                foreach (var item in listofrunningtables)
                {
                    catart.Add(item.sTab_Cat_Nm.ToString());
                }

                foreach (var item in listofrunningtables)
                {
                    tabary.Add(new tableCode { itab_cd = item.iTab_Cd.ToString(), stab_Nm = item.sTab_Nm.ToString(), stab_Cat_Nm = item.sTab_Cat_Nm });
                }

                rtabs.tablecatname = catart;
                rtabs.tableDetails = tabary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtabs;
        }

        public string GetTodaysTotalBill()
        {
            var todayTotalBills = "0";
         
            try
            {
                todayTotalBills = entities.Billing_Master.Where(x=>x.dBill_Dt>=dtFrom&&x.dBill_Dt<=dtTo).Select(x => x.iBill_No).Count().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalBills==""?"0":todayTotalBills;
        }

        public string GetTodaysTotalExpenses()
        {
            var todayTotalExp = "0";
           
            try
            {
                todayTotalExp = entities.Expenses_Tran.Where(x => x.dRec_Dt>= dtFrom && x.dRec_Dt <= dtTo).Sum(x => x.iAmount).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalExp == "" ? "0" : todayTotalExp;
        }

        public string GetTodaysTotalGuest()
        {
            var todayTotalGuest = "0";
            try
            {
                todayTotalGuest  = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo).Sum(x => x.iPax).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalGuest == "" ? "0" : todayTotalGuest;
        }

        public string GetTodaysTotalSales()
        {
            var todayTotalSales = "0";
            try
            {
                todayTotalSales = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo).Sum(x => x.iGrand_Amt).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return todayTotalSales == "" ? "0" : todayTotalSales;
        }
    }
}