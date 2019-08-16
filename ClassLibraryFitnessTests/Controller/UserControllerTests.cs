using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryFitness.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFitness.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UserControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange 
            var userName = Guid.NewGuid().ToString();
            // Act
            var controller = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            
        }
    }
}