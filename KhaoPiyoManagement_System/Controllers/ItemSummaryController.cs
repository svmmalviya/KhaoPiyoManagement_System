using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhaoPiyoManagement_System.Controllers
{
    public class ItemSummaryController : Controller
    {

        private List<breadcumb> breadcumbs = new List<breadcumb>();
        private IItemSummary IItemSummary;


        public ItemSummaryController(IItemSummary _Items) {
            IItemSummary = _Items;
        }

        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SalesRegister/Index" });
            ViewBag.breacumb = breadcumbs;


            var response = IItemSummary.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));

            if (response.isValid)
            {
                //List<ItemSummary>  summary= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Sale record from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<ItemSummary> summary = new List<ItemSummary>();
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SalesRegister/Index" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];

                ViewBag.selectedRecordDescription = "Sale record from " + dtfrom + " To " + dtto;
                var response = IItemSummary.GetTransaction(dtfrom, dtto);

                if (response.isValid)
                {
                    summary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
                }

                return Json(summary,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(summary, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetRecords()
        {
            List<ItemSummary> summaries = new List<ItemSummary>();
            var response = IItemSummary.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate));
            if (response.isValid)
            {
                summaries= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemSummary>>(response.JsonStr);
            }

            return Json(summaries, JsonRequestBehavior.AllowGet);
        }

    }
}