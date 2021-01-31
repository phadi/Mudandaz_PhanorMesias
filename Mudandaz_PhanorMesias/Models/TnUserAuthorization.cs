using System;
using System.Collections.Generic;

#nullable disable

namespace Mudandaz_PhanorMesias.Models
{
    public partial class TnUserAuthorization
    {
        public int UserAuthorizationId { get; set; }
        public int? User { get; set; }
        public int? Module { get; set; }

        public virtual TbModule ModuleNavigation { get; set; }
        public virtual TbUser UserNavigation { get; set; }
    }
}
