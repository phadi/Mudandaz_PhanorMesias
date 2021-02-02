using System;
using System.Collections.Generic;

#nullable disable

namespace Mudandaz_PhanorMesias.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbTrazaEjecucions = new HashSet<TbTrazaEjecucion>();
            TnUserAuthorizations = new HashSet<TnUserAuthorization>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TbTrazaEjecucion> TbTrazaEjecucions { get; set; }
        public virtual ICollection<TnUserAuthorization> TnUserAuthorizations { get; set; }
    }
}
