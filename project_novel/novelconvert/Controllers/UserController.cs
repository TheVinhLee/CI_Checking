using System.Collections.Generic;
using System.Web.Mvc;
using novelconvert.Models;
using MySql.Data;
using System;

namespace novelconvert.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(int id=0)
        {
	int a = 0;
            if(Request.Cookies["userID"] != null)
            {
                string userID = Request.Cookies["userID"].Value.ToString();

                UserDBModel db = new UserDBModel();
                UserModel user = db.GetUserById(Int32.Parse(userID));
                //get the total novel uploaded

                return View(user);
            }
            else
            {
                Response.Write("there is an error");
                return RedirectToAction("/Home/Index/");
            }

            
        }
        
        public ActionResult Upload(int id = 0)
        {
            if (Request.Cookies["userID"] != null)
            {
                return RedirectToAction("/Novel/Upload/");
            }
            else
            {
                Response.Write("Cannot upload");
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            UserDBModel db = new UserDBModel();
            if(Request.Cookies["userID"] != null)
            {
                id = Int32.Parse(Request.Cookies["userID"].Value.ToString());
            }
            else
            {
                return RedirectToAction("/Home/Index/");
            }
            UserModel user = db.GetUserById(id);

            return View(user);
        }
        
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            UserDBModel db = new UserDBModel();
            bool userEdit = db.EditUser(Int32.Parse(user.fID), user);

            if (userEdit)
            {
                return Redirect("Index/?Id=" + user.fID);
            }
            return Redirect("Edit/?Id=" + user.fID);
        }

        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            UserModel user = new UserModel();

            return View(user);
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            UserDBModel db = new UserDBModel();
            UserModel luser = db.UserRegister(user.fUsername, user.fPassword);
            return RedirectToAction("../Home/Index");
        }

        public ActionResult Login()
        {
            return RedirectToAction("/Register/");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if(user.fUsername != null && user.fPassword != null)
            {
                UserDBModel db = new UserDBModel();
                UserModel luser = db.UserLogin(user.fUsername, user.fPassword);

                if(luser.fUsername != null)
                {
                    Response.Cookies["user"].Value = luser.fUsername;
                    Response.Cookies["userID"].Value = luser.fID;

                    if (db.AdminChecking(luser.fUsername, luser.fPassword))
                    {
                        string id = luser.fID;
                        return Redirect(@"../Admin/Index/?id=" + id);
                    }
                    return Redirect("../Home/Index/?id=" + luser.fID);
                }
                else
                {
                    ModelState.AddModelError("","Wrong username or password");
                }
               
            }
            else
            {
                ModelState.AddModelError("", "should not empty username or password");
            }
            return RedirectToAction("../User/Login/");
        }

        public ActionResult LogOff()
        {
            if(Request.Cookies["user"] != null)
            {
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["userID"].Expires = DateTime.Now.AddDays(-1);
            }

            return Redirect("/Home/Index/");
        }

        public ActionResult MyNovel(int id = 0)
        {
            DBModel db = new DBModel();

            if (Request.Cookies["userID"] != null)
            {
                id = Int32.Parse(Request.Cookies["userID"].Value.ToString());
                //get all user novel
                List<NovelModel> listNovel = db.GetAllNovelByUserId(id);

                return View(listNovel);
            }
            else
            {
                return RedirectToAction("../Home/Index/");
            }

        }

        public ActionResult MyNovelDetail(int id = 0)
        {
            if(id != 0)
            {
                return Redirect("/Novel/Detail/?id="+id);
            }
            else{
                return RedirectToAction("../Home/Index/");
            }
        }

        public ActionResult Delete(int id =0)
        {
            DBModel db = new DBModel();

            if(Request.Cookies["userID"]!=null)
            {
                bool delete = db.RemoveNovelById(Request.Cookies["userID"].Value.ToString());

                if (delete)
                {
                    Response.Write("Delete successful");
                    return RedirectToAction("/MyNovel/");
                }
                else
                {
                    Response.Write("Can not delete");
                    return View();
                }

            }

            Response.Write("Does not have that novel");
            return View();
        }
    }
}
