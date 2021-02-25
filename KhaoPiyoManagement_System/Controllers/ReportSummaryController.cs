using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhaoPiyoManagement_System.Controllers
{
    public class ReportSummaryController : Controller
    {

        private List<breadcumb> breadcumbs = new List<breadcumb>();
        private IItemSummary IItemSummary;
        private ISalesRegister InSaleRegister;
        List<Cust_View_Tran> _trans = new List<Cust_View_Tran>();
        string dtdrom;
        string dtto;

        public ReportSummaryController(IItemSummary _Items, ISalesRegister _salesRegister)
        {
            IItemSummary = _Items;
            InSaleRegister = _salesRegister;
            dtdrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 01).ToString();
            dtto = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).ToString();
        }

        [Route("")]
        [Route("ItemSummary")]
        public ActionResult ItemSummary()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Item-Summary", routevalue = "ItemSummary" });
            ViewBag.breacumb = breadcumbs;

            Log.Write(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), "");
            var response = IItemSummary.GetTransactionItemWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));
            
            if (response.isValid)
            {
                //List<ItemSummary>  summary= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Sale record from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult ItemSummary(FormCollection form)
        {
            List<ItemSummary> summary = new List<ItemSummary>();
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Item-Summary", routevalue = "ItemSummary" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];

                ViewBag.selectedRecordDescription = "Sale record from " + dtfrom + " To " + dtto;
                var response = IItemSummary.GetTransactionItemWise(dtfrom, dtto);

                if (response.isValid)
                {
                    summary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                }

                return Json(summary, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(summary, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("")]
        [Route("MealSummary")]
        public ActionResult MealSummary()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "~/Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Meal-Summary", routevalue = "MealSummary" });
            ViewBag.breacumb = breadcumbs;


            var response = IItemSummary.GetTransactionMealWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));

            if (response.isValid)
            {
                //List<ItemSummary>  summary= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Meal report from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult MealSummary(FormCollection form)
        {
            List<ItemSummary> summary = new List<ItemSummary>();
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Meal-Summary", routevalue = "MealSummary" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];

                ViewBag.selectedRecordDescription = "Meal report from " + dtfrom + " To " + dtto;
                var response = IItemSummary.GetTransactionMealWise(dtfrom, dtto);

                if (response.isValid)
                {
                    summary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                }

                return Json(summary, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(summary, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("")]
        [Route("CatSummary")]
        public ActionResult CatSummary()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "~/Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Category-Summary", routevalue = "CatSummary" });
            ViewBag.breacumb = breadcumbs;


            var response = IItemSummary.GetTransactionCatWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));

            if (response.isValid)
            {
                //List<ItemSummary>  summary= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Category report from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult CatSummary(FormCollection form)
        {
            List<ItemSummary> summary = new List<ItemSummary>();
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "~/Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Category-Summary", routevalue = "CatSummary" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];


                ViewBag.selectedRecordDescription = "Category report from " + dtfrom + " To " + dtto;
                var response = IItemSummary.GetTransactionCatWise(dtfrom, dtto);

                if (response.isValid)
                {
                    summary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                }

                return Json(summary, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(summary, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("AuditReport")]
        public ActionResult AuditReport()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "~/Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Audit-Report", routevalue = "AuditReport" });
            ViewBag.breacumb = breadcumbs;


            var response = IItemSummary.GetTransactionAuditReport(dtdrom, dtto);

            if (response.isValid)
            {
                //List<ItemSummary>  summary= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Audit report from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }

        [HttpPost]
        public ActionResult AuditReport(FormCollection form)
        {
            List<AuditReport> summary = new List<AuditReport>();
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "~/Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Audit-Report", routevalue = "AuditReport" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"].ToString();
                string dtto = form["dtto"].ToString();



                dtto += " 23:59:59";
                dtfrom += " 00:00:01";

                dtfrom = DateTime.ParseExact(dtfrom, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm:ss");
                dtto = DateTime.ParseExact(dtto, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm:ss");

                ViewBag.selectedRecordDescription = "Audit report from " + dtfrom + " To " + dtto;
                var response = IItemSummary.GetTransactionAuditReport(dtfrom, dtto);

                if (response.isValid)
                {
                    summary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditReport>>(response.JsonStr);
                }

                return Json(summary, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(summary, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetCatRecords()
        {
            List<ItemSummary> summaries = new List<ItemSummary>();
            var response = IItemSummary.GetTransactionCatWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));
            if (response.isValid)
            {
                summaries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
            }

            return Json(summaries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAuditRecords()
        {
            List<AuditReport> auditReports = new List<AuditReport>();
            var response = IItemSummary.GetTransactionAuditReport(dtdrom, dtto);
            if (response.isValid)
            {
                auditReports = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditReport>>(response.JsonStr);
            }

            return Json(auditReports, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRecords()
        {
            List<ItemSummary> summaries = new List<ItemSummary>();
            var response = IItemSummary.GetTransactionItemWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));
            if (response.isValid)
            {
                summaries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
            }

            return Json(summaries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMealRecords()
        {
            List<ItemSummary> summaries = new List<ItemSummary>();
            var response = IItemSummary.GetTransactionMealWise(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));
            if (response.isValid)
            {
                summaries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
            }

            return Json(summaries, JsonRequestBehavior.AllowGet);
        }


        [Route("SaleRegister")]
        public ActionResult SaleRegister()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SaleRegister" });
            ViewBag.breacumb = breadcumbs;


            var response = InSaleRegister.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate), "all");

            if (response.isValid)
            {
                //_trans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cust_View_Tran>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Sale report from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult SaleRegister(FormCollection form)
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SaleRegister" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];
                string filterValue = form["r1"];



                ViewBag.selectedRecordDescription = "Sale report from " + dtfrom + " To " + dtto;
                var response = InSaleRegister.GetTransaction(dtfrom, dtto, filterValue);

                if (response.isValid)
                {
                    _trans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cust_View_Tran>>(response.JsonStr);
                }



                return Json(_trans);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public JsonResult GetSaleRecords()
        {

            var response = InSaleRegister.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate), "all");
            _trans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cust_View_Tran>>(response.JsonStr);

            return Json(_trans, JsonRequestBehavior.AllowGet);
        }
    }
}