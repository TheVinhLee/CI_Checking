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
            string email = "a@live.com";
            string password = "abcd1234";
            UserModel um = new UserModel();
            um.InputInfo(email, password, id);

            Assert.AreNotEqual(um.email, null);
            Assert.AreNotEqual(um.password, null);  
        }
        [TestMethod()]
        public void LoginTest()
        {
            UserModel um = new UserModel();
            string email = "a@live.com";
            string password = "abcd1234";
            um.InputInfo(email, password);
            Assert.AreEqual(um.getEmail(), email);
            Assert.AreEqual(um.getPassword(), password);
        }
    }
}