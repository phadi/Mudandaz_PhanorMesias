using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.ViewModels
{
    public class TbUserAuthorizationModel
    {
        public int UserAuthorizationId { get; set; }
        public int? User { get; set; }
        public int? Module { get; set; }
    }
}
