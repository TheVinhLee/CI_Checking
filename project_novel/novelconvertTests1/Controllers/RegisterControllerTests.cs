using Microsoft.VisualStudio.TestTools.UnitTesting;
using novelconvert.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Model that contains user details
            userModel db = new UserDBModel();
            string email = "a@live.com";
            string password = "abcd1234";

            UserModel um = db.UserRegister(email, password);

            Assert.AreNotEqual(um.fUsername, email);
            Assert.AreNotEqual(um.fPassword, password); 
        }
        [TestMethod()]
        public void LoginTest()
        {
            UserDBModel db = new UserDBModel();
            string email = "a@live.com";
            string password = "abcd1234";

            um = db.UserLogin(email, password);

            Assert.AreEqual(um.fUsername, email);
            Assert.AreEqual(um.fPassword, password);
        }
    }
}
