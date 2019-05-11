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
        public void MostFamous()
        {
            DBModel db = new DBModel();
            NovelModel max_voting = db.GetMaxVoting();


            Assert.IsTrue(!max_voting.Id.Equals(null));
        }
    }
}