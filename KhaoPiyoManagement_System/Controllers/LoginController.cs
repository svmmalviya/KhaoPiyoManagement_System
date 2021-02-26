using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhaoPiyoManagement_System.Controllers
{
    public class LoginController : Controller
    {
        KhaoPiyoEntities KhaoPiyoEntities = new KhaoPiyoEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtuserid ,string txtuserpass)
        {
            try
            {
                User_Master user = KhaoPiyoEntities.User_Master.Where(x => x.sUser_Nm == txtuserid&&x.sPassword==txtuserpass).FirstOrDefault();
                if (user != null)
                {
                    Session["username"] = user.sFull_nm.ToString();                  
                    Session["iuser_cd"] = user.iUser_Cd;
                    //GlobalProperties.Instance.dateformate = "MM/dd/yyyy";
                    return RedirectToAction("Index","Dashboard");
                }
                else {
                    ViewBag.error = "Invalid pin number";
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

           
        }
    }
}