using System.Collections.Generic;
using System.Web.Mvc;
using novelconvert.Models;
//using MySql.Data;

namespace novelconvert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DBModel db = new DBModel();

            //List<NovelModel> nv = db.AllNovel();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}