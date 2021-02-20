using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classes;
using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;


namespace KhaoPiyoManagement_System.Controllers
{
    public class DashboardController : Controller
    {
        KhaoPiyoEntities entities = new KhaoPiyoEntities();
        List<breadcumb> breadcumbs = new List<breadcumb>();
        DBConnect db = new DBConnect();

        IDashboard dashboard = null;

        public DashboardController(IDashboard _dashboard)
        {
            dashboard = _dashboard;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Index" });
                ViewBag.breacumb = breadcumbs;

                if (Session["username"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.totalbls = dashboard.GetTodaysTotalBill();
                    ViewBag.totalgst = dashboard.GetTodaysTotalGuest();
                    ViewBag.totalsls = dashboard.GetTodaysTotalSales();
                    ViewBag.totalexp = dashboard.GetTodaysTotalExpenses();
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return View();
        }

        [HttpPost]
        public JsonResult GetChart1()
        {
            KhaoPiyoEntities entities = new KhaoPiyoEntities();

            List<object> iData = new List<object>();
            //Creating sample data  

            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetChart()
        {
            KhaoPiyoEntities entities = new KhaoPiyoEntities();
            DataSet ds = new DataSet();
            string StrError = "";
            List<object> iData = new List<object>();
            // string[] aData = new string[2]; 

            string query = "SELECT SUM(Billing_Payment.iPay_Amount) AS TotAmt, Billing_Payment.sType, Billing_Master.dBill_Dt, PayMode_Master.sPay_Nm FROM Billing_Payment INNER JOIN "+
                  "Billing_Master ON Billing_Payment.iBill_No = Billing_Master.iBill_No AND Billing_Payment.iFin_Cd = Billing_Master.iFin_Cd AND Billing_Payment.iComp_Cd = Billing_Master.iComp_Cd AND "+
                  " Billing_Payment.iBus_Cd = Billing_Master.iBus_Cd LEFT OUTER JOIN "+
                  " PayMode_Master ON Billing_Master.iMore_Cd = PayMode_Master.iPay_Cd AND Billing_Master.iComp_Cd = PayMode_Master.iComp_Cd AND Billing_Master.iBus_Cd = PayMode_Master.iBus_Cd "+
" WHERE(Billing_Master.dBill_Dt = '02/17/2021') AND(Billing_Master.iComp_Cd = 1) AND(Billing_Master.iBus_Cd = 1) AND(Billing_Master.bOpen = 0) AND(Billing_Master.bVoid = 0) AND(Billing_Master.bNC = 0) "+
" GROUP BY Billing_Payment.sType, Billing_Master.dBill_Dt, PayMode_Master.sPay_Nm";

          

            if (db.Select(query,out ds,out StrError)) {
                if (ds != null) {
                    foreach (var row in ds.Tables[0].Rows)
                    {

                    }
                }
            }
                

            var todayDT = Convert.ToDateTime("2021-02-17");

            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in ds.Tables[0].Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            //var listOfBill = from t1 in bMaster
            //                 join t2 in bPayment
            //                 on new { t1.iBill_No, t1.iFin_Cd, t1.iBus_Cd, t1.iComp_Cd } equals new { t2.iBill_No, t2.iFin_Cd, t2.iBus_Cd, t2.iComp_Cd }
            //                 join pt in pMode.DefaultIfEmpty()
            //                 on new { t1.iBus_Cd, t1.iComp_Cd} equals new { pt.iBus_Cd, pt.iComp_Cd  }
            //                 where t1.dBill_Dt==todayDT  
            //                 select new
            //                 {
            //                     t1.dBill_Dt,
            //                     t2.iPay_Amount,
            //                     pt.sPay_Nm,
            //                     t2.sType,
            //                     t1.iMore_Cd
            //                 };






            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string data)
        {

            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
                ViewBag.breacumb = breadcumbs;

                ViewBag.totalbls = entities.Billing_Master.Select(x => x.iBill_No).Count();
                ViewBag.totalgst = entities.Billing_Master.Select(x => x.iPax).Count();
                ViewBag.totalsls = entities.Billing_Master.Sum(x => x.TAmt);
                ViewBag.totalexp = entities.Expenses_Tran.Sum(x => x.iAmount);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        public ActionResult RunningTables()
        {
            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Index" });
                breadcumbs.Add(new breadcumb { routename = "Running Tables", routevalue = "RunningTables" });
                ViewBag.breacumb = breadcumbs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            RunningTables rtabs = dashboard.GetRunningTables(Convert.ToInt32(Session["compcd"]), Convert.ToInt32(Session["buscd"]));  //Fetching running  tables
            return View(rtabs);
        }


        /// <summary>
        /// it accepts ajax call 
        /// </summary>
        /// <param name="form">input form </param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult GetRunningTableDetail(FormCollection form)
        {
            if (Request.IsAjaxRequest())
            {
                var tablecode = Convert.ToInt32(form["tableno"].ToString());
                var tableDetails = dashboard.GetRunningTableDetail(tablecode);
                return Json(tableDetails, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        /// <summary>
        /// it fetches running tables 
        /// </summary>
        /// <returns>RunningTables</returns>
        RunningTables GetRunningTables()
        {

            RunningTables rtabs = new RunningTables();

            try
            {

                var listofrunningtables = entities.View_RunningTable.Where(x => x.iComp_Cd == 1 && x.iBus_Cd == 1);

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
    }


    public class paymentModes
    {
        public double totAmount { get; set; }
        public string type { get; set; }
        public DateTime dt { get; set; }
        public string payname { get; set; }

    }
}