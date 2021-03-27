﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Classes;
using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;



namespace KhaoPiyoManagement_System.Controllers
{
    public class DashboardController : Controller
    {
        private KPEntity entities = new KPEntity();
        private List<breadcumb> breadcumbs = new List<breadcumb>();
        //DBConnect db = new DBConnect();

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
                if (object.ReferenceEquals(Session["username"], null) || Session["username"].ToString() == "")
                {
                    return RedirectToAction("Index", "Login");
                }


                var response = dashboard.GetCompanyDetails(int.Parse(Session["iuser_cd"].ToString()));

                if (response.isValid)
                {

                    GlobalProperties.Instance.companyDetails = (Company_Master)Newtonsoft.Json.JsonConvert.DeserializeObject<Company_Master>(response.JsonStr);

                    breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "/Dashboard/Index" });
                    ViewBag.breacumb = breadcumbs;

                    ViewBag.totalbls = dashboard.GetTodaysTotalBill((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalgst = dashboard.GetTodaysTotalGuest((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalsls = dashboard.GetTodaysTotalSales((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalexp = dashboard.GetTodaysTotalExpenses((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);

                    
                    //dashboardSummary.billcount = entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo &&x.bVoid==0 &&x.iComp_Cd==icomp_cd&&x.iBus_Cd==ibus_cd&&x.bNC==0).Select(x => x.iBill_No).Count().ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Select(x => x.iBill_No).Count().ToString();
                    //dashboardSummary.guest =     entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString()==""?"0": entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iPax).ToString();
                    //dashboardSummary.sale =      entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString() == "" ? "0" : entities.Billing_Master.Where(x => x.dBill_Dt >= dtFrom && x.dBill_Dt <= dtTo && x.bVoid == 0 && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd && x.bNC == 0).Sum(x => x.iGrand_Amt).ToString();
                    //dashboardSummary.expences =  entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo && x.iComp_Cd == icomp_cd && x.iBus_Cd == ibus_cd).Sum(x => x.iAmount).ToString() == "" ? "0" : entities.Expenses_Tran.Where(x => x.dRec_Dt >= dtFrom && x.dRec_Dt <= dtTo &&x.iComp_Cd==icomp_cd&&x.iBus_Cd==ibus_cd).Sum(x => x.iAmount).ToString();
                    ViewBag.companyname = Session["compname"].ToString();

                    Session["compcd"] = GlobalProperties.Instance.companyDetails.iComp_Cd;
                    Session["buscd"] = GlobalProperties.Instance.companyDetails.ResturantID;

                    //string logoImagePath = Server.MapPath("~/Images");
                    //string[] logoImageFiles = Directory.GetFiles(logoImagePath);

                    //foreach (var item in logoImageFiles)
                    //{
                    //    var strInd = item.LastIndexOf('\\') + 1;

                    //    if (item.ToString().ToLower().Contains(GlobalProperties.Instance.companyDetails.ImgName.ToLower())) {
                    //        Session["companylogo"] = GlobalProperties.Instance.companyDetails.ImgName;
                    //    }
                    //}
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (Exception ex)
            {

                throw;
            }


            return View();
        }

        [HttpPost]
        public JsonResult GetChart()
        {

            var iData = dashboard.GetDailyMoneyCollection((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetMyChart(string dtFrom, string dtto)
        {

            var iData = dashboard.GetDailyMoneyCollection((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string data)
        {

            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "/Dashboard/Index" });
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

        public ActionResult MyDashboard()
        {
            DashboardSummary dSummary = new DashboardSummary();
            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "/Dashboard/Index" });
                breadcumbs.Add(new breadcumb { routename = "My-Dashboard", routevalue = "/Dashboard/MyDashboard" });
                ViewBag.breacumb = breadcumbs;

            }
            catch (Exception ex)
            {

                throw;
            }

            return View(dSummary);
        }



        public ActionResult GetDashboardSummary() {
            DashboardSummary dSummary = new DashboardSummary();
            try
            {
                string dtfrom = DateTime.Now.ToString("MM-dd-yyyy");
                string dtto = DateTime.Now.ToString("MM-dd-yyyy");

                var response = dashboard.GetDashboardSummary(dtfrom, dtto, (int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                
                if (response.isValid)
                {
                    dSummary = Newtonsoft.Json.JsonConvert.DeserializeObject<DashboardSummary>(response.JsonStr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(dSummary, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MyDashboard(FormCollection form)
        {

            try
            {

                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "/Dashboard/Index" });
                breadcumbs.Add(new breadcumb { routename = "My-Dashboard", routevalue = "/Dashboard/MyDashboard" });
                ViewBag.breacumb = breadcumbs;

                DashboardSummary dSummary = new DashboardSummary();
                if (form["dtfrom"] != "" && form["dtto"] != "")
                {

                    string dtfrom = DateTime.ParseExact(form["dtfrom"], "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                    string dtto = DateTime.ParseExact(form["dtto"], "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");

                  
                    var response = dashboard.GetDashboardSummary(dtfrom, dtto, (int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);

                    if (response.isValid)
                    {
                        dSummary = Newtonsoft.Json.JsonConvert.DeserializeObject<DashboardSummary>(response.JsonStr);
                    }

                    return Json(dSummary,JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

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