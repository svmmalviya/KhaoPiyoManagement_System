using System;
using System.Collections.Generic;
using System.Data;
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
        private KhaoPiyoEntities entities = new KhaoPiyoEntities();
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
                if (object.ReferenceEquals(Session["username"], null))
                {
                    return RedirectToAction("Index", "Login");
                }


                var response = dashboard.GetCompanyDetails(int.Parse(Session["iuser_cd"].ToString()));

                if (response.isValid)
                {

                    GlobalProperties.Instance.companyDetails = (Company_Master)Newtonsoft.Json.JsonConvert.DeserializeObject<Company_Master>(response.JsonStr);

                    breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
                    ViewBag.breacumb = breadcumbs;

                    ViewBag.totalbls = dashboard.GetTodaysTotalBill((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalgst = dashboard.GetTodaysTotalGuest((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalsls = dashboard.GetTodaysTotalSales((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.totalexp = dashboard.GetTodaysTotalExpenses((int)GlobalProperties.Instance.companyDetails.ResturantID, GlobalProperties.Instance.companyDetails.iComp_Cd);
                    ViewBag.companyname = GlobalProperties.Instance.companyDetails.sComp_Nm;

                    Session["compcd"] = GlobalProperties.Instance.companyDetails.iComp_Cd;
                    Session["buscd"] = GlobalProperties.Instance.companyDetails.ResturantID;

                    string logoImagePath = Server.MapPath("~/Images");
                    string[] logoImageFiles = Directory.GetFiles(logoImagePath);

                    foreach (var item in logoImageFiles)
                    {
                        var strInd = item.LastIndexOf('\\') + 1;

                        if (item.ToString().ToLower().Contains(GlobalProperties.Instance.companyDetails.ImgName.ToLower())) {
                            Session["companylogo"] = GlobalProperties.Instance.companyDetails.ImgName;
                        }
                    }
                }
                else {
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



    }


    public class paymentModes
    {
        public double totAmount { get; set; }
        public string type { get; set; }
        public DateTime dt { get; set; }
        public string payname { get; set; }

    }
}