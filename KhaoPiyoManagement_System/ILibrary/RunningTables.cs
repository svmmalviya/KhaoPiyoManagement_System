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
    public class RunningTables : IRunningTables
    {
        
        Entities entities;
        DateTime dtFrom;
        DateTime dtTo;
        private string query;
        private DBConnect dbConnect;
        private DataSet ds;
        private string error;
        private List<View_RunningTable> listofrunningtables;
        private static List<View_Tran> trans;

        public RunningTables() {
            entities = new Entities();
            dbConnect = new DBConnect();
        }


        public List<TableDetails> GetRunningTableDetail(int tablecd)
        {

            query = "select * from View_Tran where iTab_Cd="+tablecd+" and bOpen=1 and iComp_Cd=1 and iBus_Cd=1";

            if (dbConnect.Select(query, out ds, out error))
            {
                trans = CommonMethod.ConvertToList<View_Tran>(ds.Tables[0]);
            }

            List<TableDetails> tableDetails = new List<TableDetails>();
            try
            {
                if (trans.Count > 0)
                {
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
                else {
                    tableDetails = new List<TableDetails>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return tableDetails;
        }

        public List<TableDetails> GetBill(int tablecd)
        {

            query = "select * from View_Tran";

            if (dbConnect.Select(query, out ds, out error))
            {

                trans = CommonMethod.ConvertToList<View_Tran>(ds.Tables[0]);
            }

            List<TableDetails> tableDetails = new List<TableDetails>();
            try
            {
                if (trans.Count > 0)
                {
                    foreach (var item in trans)
                    {
                        if (item.iBill_No == tablecd)
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
                else {

                    tableDetails = new List<TableDetails>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return tableDetails;
        }

        public Models.RunningTables GetRunningTables(int iCompany_Cd,int iBusiness_Cd)
        {
           Models.RunningTables rtabs = new Models.RunningTables();
            query = "select * from View_RunningTable";

            if (dbConnect.Select(query, out ds, out error))
            {

                listofrunningtables = CommonMethod.ConvertToList<View_RunningTable>(ds.Tables[0]);
            }
            try
            {

                List<string> catart = new List<string>();
                List<tableCode> tabary = new List<tableCode>();


                foreach (var item in listofrunningtables)
                {
                    if (!catart.Contains(item.sTab_Cat_Nm.ToString()))
                    {
                        catart.Add(item.sTab_Cat_Nm.ToString());
                    }
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

    }
}