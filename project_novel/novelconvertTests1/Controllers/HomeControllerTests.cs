using Microsoft.VisualStudio.TestTools.UnitTesting;
using novelconvert.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using novelconvert.Models;

namespace novelconvert.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetAllNovel()
        {
            DBModel db = new DBModel();
            List<NovelModel> listNovel = db.AllNovel();

            Assert.IsTrue(listNovel.Count() != 0);
        }

        [TestMethod()]
        public void GetNovelById()
        {
            string id = "1";

            DBModel db = new DBModel();
            NovelModel novel = db.SelectOneNovel(id);

            Assert.AreEqual(novel.Id, id);
        }

        [TestMethod()]
        public void AddingNovel()
        {
            NovelModel nv = new NovelModel();
            nv.Name = "new novel";
            nv.Image_link = "#";
            nv.Author = "Tony";
            nv.Chap_number = 1;

            DBModel db = new DBModel();
            bool novel = db.AddNewNovel(nv);

            Assert.IsTrue(novel); //check that add new novel is success or not
        }

        [TestMethod()]
        public void RemoveBook()
        {
            string id = "1";

            DBModel db = new DBModel();
            bool novel = db.RemoveNovelById(id);

            Assert.IsTrue(novel); //check that add new novel is success or not
        }

        [TestMethod()]
        public void EditNovelInfor()
        {
            DBModel db = new DBModel();
            //get novel by id
            NovelModel nv = db.SelectOneNovel("1");
            //new infor, cannot change id
            NovelModel newNv = new NovelModel();
            newNv.Name = "Hello";
            newNv.Author = "Fire";

            bool novel = db.EditNovel(nv, newNv);

            Assert.IsTrue(novel); //check that add new novel is success or not
        }
    }
}