using System.Collections.Generic;
using System.Web.Mvc;
using novelconvert.Models;
using MySql.Data;
using System;

namespace novelconvert.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index(string id="0")
        {
            UserDBModel db = new UserDBModel();
            if(Request.Cookies["userID"] != null)
            {
                id = Request.Cookies["userID"].Value.ToString();
            }
            
            UserModel user = db.GetUserById(Int32.Parse(id));
            List<UserModel> nv = db.GetAllUser(user.fUsername,user.fPassword);
            if(!db.AdminChecking(Int32.Parse(id))) return RedirectToAction("../Home/Index");
        
            return View(nv);
        }
        
        public ActionResult Delete(int id, int value)
        {
            UserDBModel db = new UserDBModel();
            bool removeUser = db.RemoveUserById(id.ToString());
            if(removeUser) return Redirect(@"../Index/?id=" + value);

            return View("Cannot remove this user");

        }

        public ActionResult Details(int id)
        {
            return Redirect("~/User/Index/?id="+id);
        }
    }
}
