using Microsoft.EntityFrameworkCore;
using Mudandaz_PhanorMesias.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MudanzasTest
{
    public class TestBase
    {
        protected sbMudanzaPMContext ConstruitContexto(string DbName)
        {
            var options = new DbContextOptionsBuilder<sbMudanzaPMContext>()
                .UseInMemoryDatabase(DbName).Options;

            var dbContext = new sbMudanzaPMContext(options);

            return dbContext;
        }
    }
}
