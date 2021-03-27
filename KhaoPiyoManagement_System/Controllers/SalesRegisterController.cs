using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace KhaoPiyoManagement_System.Controllers
{
    public class SalesRegisterController : Controller
    {

        private List<breadcumb> breadcumbs = new List<breadcumb>();
        private ISalesRegister iSaleRegister;
        List<Cust_View_Tran> _trans = new List<Cust_View_Tran>();
        // GET: SalesRegister

        public SalesRegisterController(ISalesRegister _salesRegister)
        {
            if (GlobalProperties.Instance.dateformate == null)
            {
                RedirectToAction("Index","Login");
            }
            iSaleRegister = _salesRegister;
        }

        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SalesRegister/Index" });
            ViewBag.breacumb = breadcumbs;


            var response = iSaleRegister.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate), "all",1,1);

            if (response.isValid)
            {
                //_trans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cust_View_Tran>>(response.JsonStr);
                ViewBag.selectedRecordDescription = "Sale record from " + DateTime.Now.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");

            }

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
            breadcumbs.Add(new breadcumb { routename = "Sale-Register", routevalue = "SalesRegister/Index" });
            ViewBag.breacumb = breadcumbs;


            if (form["dtfrom"] != "" && form["dtto"] != "")
            {

                string dtfrom = form["dtfrom"];
                string dtto = form["dtto"];
                string filterValue = form["r1"];



                ViewBag.selectedRecordDescription = "Sale records from " + dtfrom + " To " + dtto;
                var response = iSaleRegister.GetTransaction(dtfrom, dtto, filterValue,1,1);

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
        public JsonResult GetRecords()
        {

            var response = iSaleRegister.GetTransaction(DateTime.Now.ToString(GlobalProperties.Instance.dateformate), DateTime.Now.ToString(GlobalProperties.Instance.dateformate), "all",1,1);
            _trans = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cust_View_Tran>>(response.JsonStr);

            return Json(_trans, JsonRequestBehavior.AllowGet);
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 




}