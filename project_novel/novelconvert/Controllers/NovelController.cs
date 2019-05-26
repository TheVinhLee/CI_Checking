using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using novelconvert.Models;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace novelconvert.Controllers
{
    public class NovelController : Controller
    {

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DBModel db = new DBModel();
            NovelModel novel = db.SelectOneNovel(id.ToString());
            
            return View(novel);
        }

        [HttpPost]
        public ActionResult Edit(NovelModel novel)
        {
            DBModel db = new DBModel();
            bool editCheck = db.EditNovel(Int32.Parse(novel.Id), novel);

            if (editCheck)
            {
                return Redirect("/Novel/Detail/?id=" + novel.Id);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {

            if(Request.Cookies["userID"] != null)
            {
                NovelModel nv = new NovelModel();
                nv.Owner = Request.Cookies["userID"].Value.ToString();
                return View(nv);
            }
            else
            {
                return Redirect("/Home/Index/");
            }
        }

        [HttpPost]
        public ActionResult Upload(NovelModel novel)
        {
            if(novel.Name != null && novel.Author!= null && novel.Link != null)
            {
                novel.upload_date = DateTime.Now;
                novel.Owner = Request.Cookies["userID"].Value.ToString();

                string image_sourceFile = @"C:\Users\lythe\Desktop\" + novel.Image_link;
                string image_destinationFile = Server.MapPath(@"~/database/Image/" + novel.Image_link);

                string sourceFile = @"C:\Users\lythe\Desktop\" + novel.Link;
                string destinationFile = Server.MapPath(@"~/database/novel_book/" + novel.Link);

                System.IO.File.Copy(image_sourceFile, image_destinationFile, true);
                System.IO.File.Copy(sourceFile, destinationFile, true);

                DBModel db = new DBModel();

                int chap = 1;
                //get maximum chapter
                using (StreamReader sr = new StreamReader(Server.MapPath("~/database/novel_book/" + novel.Link)))
                {
                    string line = sr.ReadLine(); //first is a chapter
                    while (line != null)
                    {
                        if (line.ToLower() == ("chapter " + chap))
                        {
                            chap += 1;
                        }

                        line = sr.ReadLine();
                    }
                }

                novel.Chap_number = chap-1;

                db.AddNewNovel(novel);
                
                return Redirect("/Home/Index/");
            }
            else
            {
                Response.Write("Novel name, Author and link could not be empty");
                return Redirect("/Novel/Upload/");
            }

            
        }

        public ActionResult Detail(int id)
        {
            DBModel db = new DBModel();
            NovelModel novel = db.SelectOneNovel(id.ToString());

            return View(novel);
        }
    }
}
