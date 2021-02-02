using Mudandaz_PhanorMesias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.ViewModels
{
    public class TbTrazaEjecucionModel
    {
        public int TrazaEjecucionId { get; set; }
        public DateTime? Date { get; set; }
        public string EjecutorId { get; set; }
        public int? UserId { get; set; }
        public string Observations { get; set; }
        public string Login { get; set; }

        public string DateStr { 
            get
            {
                string dateStr = string.Empty;
                if (Date != null)
                {
                    dateStr = Date.Value.ToLongDateString();
                    
                }
                return dateStr;
            }
        }

        public TbTrazaEjecucionModel() { }

        public TbTrazaEjecucionModel(TbTrazaEjecucion tbTrazaEjecucion) {
            TrazaEjecucionId = tbTrazaEjecucion.TrazaEjecucionId;
            Date = tbTrazaEjecucion.Date;
            EjecutorId = tbTrazaEjecucion.EjecutorId;
            UserId = tbTrazaEjecucion.UserId;
            Observations = tbTrazaEjecucion.Observations;
        }
    }
}
