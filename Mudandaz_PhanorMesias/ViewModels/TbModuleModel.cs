using Mudandaz_PhanorMesias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.ViewModels
{
    public class TbModuleModel
    {
        public int ModuleId { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }

        public bool IsSelected;

        public TbModuleModel() { }

        public TbModuleModel(TbModule tbModule)
        {
            ModuleId = tbModule.ModuleId;
            Module = tbModule.Module;
            Description = tbModule.Description;
            Url = tbModule.Url;
            Image = tbModule.Image;
        }
    }
}
