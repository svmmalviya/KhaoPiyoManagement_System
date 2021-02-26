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
        KhaoPiyoEntities entities;
        DateTime dtFrom;
        DateTime dtTo;

        public RunningTables() {
            entities = new KhaoPiyoEntities();
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

        public List<TableDetails> GetBill(int tablecd)
        {
            List<TableDetails> tableDetails = new List<TableDetails>();
            try
            {
                var trans = entities.View_Tran.ToList();

                foreach (var item in trans)
                {
                    if (item.iBill_No == tablecd )
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

        public Models.RunningTables GetRunningTables(int iCompany_Cd,int iBusiness_Cd)
        {
           Models.RunningTables rtabs = new Models.RunningTables();

            try
            {
                var listofrunningtables = entities.View_RunningTable.Where(x => x.iComp_Cd == iCompany_Cd && x.iBus_Cd == iBusiness_Cd);

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