using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Mudandaz_PhanorMesias;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mudandaz_PhanorMesias.Controllers;
using System.Net.Http;
using System.Web.Http;
using Mudandaz_PhanorMesias.ViewModels;

namespace NUnitTestMudanzas
{
    class MudanzaControllerTest
    {
        [Test]
        public void GetReturnsProduct()
        {
            Mudandaz_PhanorMesias.Models.sbMudanzaPMContext context = new Mudandaz_PhanorMesias.Models.sbMudanzaPMContext();
            
            var controller = new MudanzaController(context);

            // Assert
            List<TbTrazaEjecucionModel> executions = controller.GetTraceExecutions(); 
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(executions.Count > 0);
        }
    }
}
