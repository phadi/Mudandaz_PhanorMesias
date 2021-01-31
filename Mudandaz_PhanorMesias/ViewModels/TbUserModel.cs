using Mudandaz_PhanorMesias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.ViewModels
{
    public class TbUserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public TbUserModel(){}

        public TbUserModel (TbUser tbUser)
        {
            UserId = tbUser.UserId;
            Name = tbUser.Name;
            Login = tbUser.Login;
            Password = tbUser.Password;
        }
    }
}
