using System;
using System.Collections.Generic;

#nullable disable

namespace Mudandaz_PhanorMesias.Models
{
    public partial class TbModule
    {
        public TbModule()
        {
            TnUserAuthorizations = new HashSet<TnUserAuthorization>();
        }

        public int ModuleId { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public virtual ICollection<TnUserAuthorization> TnUserAuthorizations { get; set; }
    }
}
