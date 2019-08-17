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
        public void SetNewUserDataTest()
        {
            // Arrange
            var nname = Guid.NewGuid().ToString();
            var gender = Guid.NewGuid().ToString();
            DateTime birthDate = new DateTime(1999, 11, 15);
            var weight = 100;
            var height = 1000;

            // Act
            var controller = new UserController(nname);
            controller.SetNewUserData(gender, birthDate, weight, height);

            var controller2 = new UserController(nname);
            // Assert

            Assert.AreEqual(nname, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);


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