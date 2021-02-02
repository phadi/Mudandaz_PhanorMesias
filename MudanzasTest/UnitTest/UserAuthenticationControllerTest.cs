using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mudandaz_PhanorMesias.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MudanzasTest.UnitTest
{
    [TestClass]
    public class UserAuthenticationControllerTest: TestBase
    {
        [TestMethod]
        public void GetUserTest_OK()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            var resp = controller.GetUser("log1", "1111");

            Assert.AreEqual(1, resp.UserId);

        }

        [TestMethod]
        public void GetUserTest_Fail()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            var resp = controller.GetUser("log1", "222");

            Assert.AreEqual(0, resp.UserId);

        }
    }
}
