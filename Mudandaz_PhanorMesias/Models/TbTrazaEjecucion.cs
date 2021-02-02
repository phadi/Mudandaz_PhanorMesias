using System;
using System.Collections.Generic;

#nullable disable

namespace Mudandaz_PhanorMesias.Models
{
    public partial class TbTrazaEjecucion
    {
        public int TrazaEjecucionId { get; set; }
        public DateTime? Date { get; set; }
        public string EjecutorId { get; set; }
        public int? UserId { get; set; }
        public string Observations { get; set; }

        public virtual TbUser User { get; set; }
    }
}
