using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.ViewModels
{
    public class TbUserAuthorizationModel
    {
        public TbUserModel User { get; set; }
        public List<TbModuleModel> Modules { get; set; }

        public TbUserAuthorizationModel() { }

        public TbUserAuthorizationModel(TbUserModel _User, List<TbModuleModel> _Modules)
        {
            User = _User;
            Modules = _Modules;
        }
    }
}
