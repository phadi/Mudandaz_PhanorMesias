﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mudandaz_PhanorMesias.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MudanzasTest.UnitTest
{
    [TestClass]
    public class MudanzaControllerTest: TestBase
    {
        [TestMethod]
        public void GetTraceExecutionsTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });
            context.TbTrazaEjecucions.Add(new Mudandaz_PhanorMesias.Models.TbTrazaEjecucion() { TrazaEjecucionId = 1, Date = DateTime.Now, EjecutorId = "2222", UserId = 1 });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);

            var controller = new ViajesController(context2);
            var resp = controller.GetTraceExecutions();

            Assert.AreEqual(1, resp.Count); //{"DateTime":"2021-02-02T22:23:12.287Z","EjecutorId":"98765","UserId":1}

        }

        [TestMethod]
        public void saveTraceTest()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConstruitContexto(dbName);

            context.TbUsers.Add(new Mudandaz_PhanorMesias.Models.TbUser() { UserId = 1, Login = "log1", Name = "log1", Password = "1111" });

            context.SaveChanges();

            var context2 = ConstruitContexto(dbName);
            string param = "{\"DateTime\":\"2021 - 02 - 02T22: 23:12.287Z\",\"EjecutorId\":\"98765\",\"UserId\":1}";
            var controller = new ViajesController(context2);
            var resp = controller.saveTrace(param); 

            Assert.IsTrue(resp.TrazaEjecucionId > 0); 

        }
    }
}
