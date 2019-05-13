using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using novelconvert.Models;
using System.Web.Mvc;

namespace novelconvert.Controllers
{
    public class ReadingController: Controller
    {
        public ActionResult Index(string id, string chapter)
        {
            ViewBag.BookID = id;
            ViewBag.Chapter = chapter;

            DBModel db = new DBModel();
            NovelModel nv = db.SelectOneNovel(id);
            return View(nv);
        }
    }
}
