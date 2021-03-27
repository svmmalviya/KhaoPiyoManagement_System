using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KhaoPiyoManagement_System.Controllers
{
    public class LoginController : Controller
    {

        MasterEntities MasterEntities = new MasterEntities();


        public LoginController()
        {
            GlobalProperties.Instance.conStringName = "khaopiyo";
        }
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.errorclass = " errorBox  w-0 h-0";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(string txtuserid, string txtuserpass)
        {
            try
            {
                string name = "";

                if (txtuserid != "")
                {

                    var user = MasterEntities.Users.Where(x => x.Email.Trim() == txtuserid.Trim() && x.Password.Trim() == txtuserpass.Trim()).FirstOrDefault();

                    if (user != null)
                    {
                        var rest = MasterEntities.Resturants.Where(x => x.ResturantID == user.ResturantID).FirstOrDefault();
                        GlobalProperties.Instance.conStringName = rest.ConnectionString;
                        Session["username"] = "1"; //user.sFull_nm.ToString();
                        Session["compname"] = rest.Name != null && rest.Name != "" ? rest.Name : "";
                        Session["iuser_cd"] = 1;//user.iUser_Cd;
                                                //GlobalProperties.Instance.dateformate = "MM/dd/yyyy";
                                                //return RedirectToAction("Index", "Dashboard");

                        var authTicket = new FormsAuthenticationTicket(
                          1,
                          Convert.ToString( user.UserId),  //user id  
                          DateTime.Now,
                          DateTime.Now.AddSeconds(50),  // expiry  
                          true,  //true to remember  
                          "", //roles   
                          "/"
                           );

                        //encrypt the ticket and add it to a cookie  
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                        cookie.Expires = DateTime.Now.AddSeconds(50);
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ViewBag.error = "Invalid userid and password entered!";
                        ViewBag.errorclass = "d-block errorBox  w-100";
                        return View();
                    }


                }
                else
                {

                }



                //if (ConfigurationManager.AppSettings[name] != null)
                //{

                //}

                // User_Master user = KPEntity.User_Master.Where(x => x.sUser_Nm == txtuserid&&x.sPassword==txtuserpass).FirstOrDefault();
                //if (user != null)
                //{
                //    Session["username"] = user.sFull_nm.ToString();                  
                //    Session["iuser_cd"] = user.iUser_Cd;
                //    //GlobalProperties.Instance.dateformate = "MM/dd/yyyy";
                //    return RedirectToAction("Index","Dashboard");
                //}
                //else {
                //    ViewBag.error = "Invalid pin number";
                //    return View();
                //}
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }
    }
}