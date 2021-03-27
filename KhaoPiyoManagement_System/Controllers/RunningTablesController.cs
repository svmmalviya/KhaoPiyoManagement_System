using KhaoPiyoManagement_System.ILibrary;
using KhaoPiyoManagement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhaoPiyoManagement_System.Controllers
{
    public class RunningTablesController : Controller
    {
        private KPEntity entities = new KPEntity();
        private List<breadcumb> breadcumbs = new List<breadcumb>();
        // GET: RuinningTables
        IRunningTables runningTables;

        public RunningTablesController(IRunningTables _running)
        {
            runningTables = _running;
        }
        public ActionResult Index()
        {
            try
            {
                breadcumbs.Add(new breadcumb { routename = "Home", routevalue = "Dashboard/Index" });
                breadcumbs.Add(new breadcumb { routename = "Running Tables", routevalue = "RunningTables" });
                ViewBag.breacumb = breadcumbs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Models.RunningTables rtabs = runningTables.GetRunningTables(Convert.ToInt32(Session["compcd"]), Convert.ToInt32(Session["buscd"]));  //Fetching running  tables
            //Models.RunningTables rtabs = null;
            return View(rtabs);
        }


        /// <summary>
        /// it accepts ajax call 
        /// </summary>
        /// <param name="form">input form</param>
        /// <returns>json data</returns>
        [HttpPost]
        public JsonResult GetRunningTableDetail(FormCollection form)
        {
            if (Request.IsAjaxRequest())
            {
                var tablecode = Convert.ToInt32(form["tableno"].ToString());
                var tableDetails = runningTables.GetRunningTableDetail(tablecode);
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
        Models.RunningTables GetRunningTables()
        {

            Models.RunningTables rtabs = new Models.RunningTables();

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
}