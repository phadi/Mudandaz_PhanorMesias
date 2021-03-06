﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mudandaz_PhanorMesias.Models;
using Mudandaz_PhanorMesias.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudandaz_PhanorMesias.Controllers
{
    [Route("api/[controller]")]
    public class ViajesController : Controller
    {
        private Models.sbMudanzaPMContext db;       

        public ViajesController(Models.sbMudanzaPMContext context)
        {
            db = context;
        }

        [HttpGet("[action]")]
        public List<TbTrazaEjecucionModel> GetTraceExecutions()
        {
            List<TbTrazaEjecucionModel> trazaEjecuciones = (from u in db.TbTrazaEjecucions
                                                            join p in db.TbUsers on u.UserId equals p.UserId
                                                            select new TbTrazaEjecucionModel
                                                            {
                                                                Date = u.Date,
                                                                EjecutorId = u.EjecutorId,
                                                                UserId = u.UserId,
                                                                Observations = u.Observations,
                                                                Login = p.Login
                                                            }).ToList();

            if (trazaEjecuciones == null)
            {
                return new List<TbTrazaEjecucionModel>();
            }

            return trazaEjecuciones;
        }

        [HttpPost("[action]")]
        public TbTrazaEjecucionModel saveTrace(string tbTrazaEjecucionModel)
        {
            try
            {
                string login = string.Empty;
                TbTrazaEjecucion trazaEjecucion = JsonConvert.DeserializeObject<TbTrazaEjecucion>(tbTrazaEjecucionModel);
                if (trazaEjecucion != null)
                {
                    TbUser usr = db.TbUsers.Find(trazaEjecucion.UserId);
                    login = usr.Login;

                    trazaEjecucion.Date = DateTime.Now;
                    db.TbTrazaEjecucions.Add(trazaEjecucion);
                    db.SaveChanges();
                }
                else
                {
                    trazaEjecucion = new TbTrazaEjecucion();
                }

                TbTrazaEjecucionModel trazaEjecucionModel = new TbTrazaEjecucionModel(trazaEjecucion);
                trazaEjecucionModel.Login = login;

                return trazaEjecucionModel;
            }
            catch(Exception ex)
            {
                TbTrazaEjecucionModel trazaEjecucionModel = new TbTrazaEjecucionModel();
                trazaEjecucionModel.TrazaEjecucionId = -1;
                trazaEjecucionModel.Observations = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                return trazaEjecucionModel;
            }
            
        }
    }
}
