using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mudandaz_PhanorMesias.Controllers;
using Mudandaz_PhanorMesias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MudanzasTest.UnitTest
{
    [TestClass]
    public class UserAuthenticationControllerTest: TestBase
    {
        [TestMethod]
        public void GetUserTest_AuthenticateOK()
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
        public void GetUserTest_FailAuthenticate()
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

        [TestMethod]
        public void GetUserListTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });
            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 2, Login = "log2", Name = "log2", Password = "2222" });
            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 3, Login = "log3", Name = "log3", Password = "3333" });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            var resp = controller.GetUserList();
            List<TbUserModel> lst = (List<TbUserModel>)resp;
            Assert.AreEqual(3, lst.Count);

        }

        [TestMethod]
        public void GetModulesByUserTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 1, Module = "mod1", Description = "mod1", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 2, Module = "mod2", Description = "mod2", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 3, Module = "mod3", Description = "mod3", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 4, Module = "mod4", Description = "mod4", Image = "", Url = "" });

            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 1, User = 1, Module = 1 });
            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 2, User = 1, Module = 2 });
            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 3, User = 1, Module = 3 });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            var resp = controller.GetModulesByUser(1);
            List<TbModuleModel> lst = (List<TbModuleModel>)resp;
            Assert.AreEqual(3, lst.Count);
        }

        [TestMethod]
        public void GetModulesByUsersTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });
            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 2, Login = "log2", Name = "log2", Password = "222" });

            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 1, Module = "mod1", Description = "mod1", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 2, Module = "mod2", Description = "mod2", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 3, Module = "mod3", Description = "mod3", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 4, Module = "mod4", Description = "mod4", Image = "", Url = "" });

            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 1, User = 1, Module = 1 });
            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 2, User = 1, Module = 2 });
            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 3, User = 1, Module = 3 });

            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 4, User = 2, Module = 2 });
            context.TnUserAuthorizations.Add(new Mudandaz_PhanorMesias.Models.TnUserAuthorization() { UserAuthorizationId = 5, User = 2, Module = 3 });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            List<TbUserAuthorizationModel> resp = controller.GetModulesByUsers();
            Assert.AreEqual(2, resp.Count);

        }

        [TestMethod]
        public void GetModulesTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 1, Module = "mod1", Description = "mod1", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 2, Module = "mod2", Description = "mod2", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 3, Module = "mod3", Description = "mod3", Image = "", Url = "" });
            context.TbModules.Add(new Mudandaz_PhanorMesias.Models.TbModule() { ModuleId = 4, Module = "mod4", Description = "mod4", Image = "", Url = "" });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new UserAuthenticationController(context2);
            List<TbModuleModel> resp = controller.GetModules();
            Assert.AreEqual(4, resp.Count);

        }
    }
}
