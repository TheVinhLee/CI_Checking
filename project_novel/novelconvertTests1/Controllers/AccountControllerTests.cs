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
    public class RegisterControllerTest
    {

        //Test method ensures that a email and username are inputted
        //and properly handled when the register button is clicked
        [TestMethod()]
        public void RegisterTest()
        {
            UserDBModel db = new UserDBModel();
            //Model that contains user details
            string email = "a@live.com";
            string password = "abcd1234";

            UserModel um = db.UserRegister(email, password);

            Assert.AreEqual(um.fUsername, email);
            Assert.AreEqual(um.fPassword, password);
        }
        [TestMethod()]
        public void LoginTest()
        {
            UserDBModel db = new UserDBModel();

            string email = "a@live.com";
            string password = "abcd1234";

            UserModel um = db.UserLogin(email, password);

            Assert.AreEqual(um.fUsername, email);
            Assert.AreEqual(um.fPassword, password);
        }

        [TestMethod()]
        public void CheckingExistUser()
        {
            UserDBModel db = new UserDBModel();

            string username = "a@live.com";

            bool um = db.UserNameExistChecking(username);

            Assert.IsFalse(um); //false mean does not exist, true mean user exist
        }
    }
}