using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserAuthenticationController : Controller
    {
        private Models.sbMudanzaPMContext db;

        public UserAuthenticationController(Models.sbMudanzaPMContext context)
        {
            db = context;
        }

        [HttpGet("[action]")]
        public TbUserModel GetUser(string login, string psw)
        {
           TbUser logedUser = (from u in db.TbUsers
                               where u.Login == login && u.Password == psw
                               select u).FirstOrDefault();

            if(logedUser == null)
            {
                return new TbUserModel();
            }

            TbUserModel logedUserModel = new TbUserModel(logedUser);
            return logedUserModel;
        }

        [HttpGet("[action]")]
        public IEnumerable<TbUserModel> GetUserList()
        {
            List<TbUserModel> userList = (from u in db.TbUsers
                                         select new TbUserModel
                                         {
                                             UserId = u.UserId,
                                             Name = u.Name,
                                             Login = u.Login,
                                             Password = u.Password
                                         }).ToList();

            if (userList == null)
            {
                return new List<TbUserModel>();
            }

            return userList;
        }

        [HttpGet("[action]")]
        public IEnumerable<TbModuleModel> GetModulesByUser(int? userId)
        {
            List<TbModuleModel> moduleList = (from u in db.TnUserAuthorizations
                                            join m in db.TbModules on u.Module equals m.ModuleId
                                            where u.User == userId
                                            select new TbModuleModel
                                            {
                                                ModuleId = m.ModuleId,
                                                Module = m.Module,
                                                Description = m.Description,
                                                Url = m.Url,
                                                Image = m.Image
                                            }).ToList();

            if (moduleList == null)
            {
                return new List<TbModuleModel>();
            }

            return moduleList;
        }

        [HttpGet("[action]")]
        public List<TbUserAuthorizationModel> GetModulesByUsers()
        {
            List<TbUserAuthorizationModel> usersList = new List<TbUserAuthorizationModel>();
            List<TbUserModel> users = (from u in db.TbUsers
                                        select new TbUserModel
                                        {
                                            UserId = u.UserId,
                                            Name = u.Name,
                                            Login = u.Login,
                                            Password = u.Password
                                        }).ToList();

            foreach(TbUserModel tbUserModel in users)
            {
                List<TbModuleModel> moduleList = (from u in db.TnUserAuthorizations
                                                  join m in db.TbModules on u.Module equals m.ModuleId
                                                  where u.User == tbUserModel.UserId
                                                  select new TbModuleModel
                                                  {
                                                      ModuleId = m.ModuleId,
                                                      Module = m.Module,
                                                      Description = m.Description,
                                                      Url = m.Url,
                                                      Image = m.Image
                                                  }).ToList();

                TbUserAuthorizationModel tbUserAuthorizationModel = new TbUserAuthorizationModel(tbUserModel, moduleList);
                usersList.Add(tbUserAuthorizationModel);
            }

            return usersList;
        }

        [HttpPost("[action]")]
        public TbUserModel saveUser(string tbUserModel)
        {
            TbUser user = JsonConvert.DeserializeObject<TbUser>(tbUserModel);
            if (user != null)
            {
                if (user.UserId == 0)
                {
                    db.TbUsers.Add(user);
                    db.SaveChanges();

                    TnUserAuthorization autor = new TnUserAuthorization();
                    autor.User = user.UserId;
                    autor.Module = 2;
                    db.TnUserAuthorizations.Add(autor);

                    TnUserAuthorization autor1 = new TnUserAuthorization();
                    autor1.User = user.UserId;
                    autor1.Module = 3;
                    db.TnUserAuthorizations.Add(autor1);

                    db.SaveChanges();
                }
                else
                {
                    TbUser userEdit = db.TbUsers.Find(user.UserId);
                    if (userEdit != null && userEdit.UserId > 0)
                    {
                        userEdit.Name = user.Name;
                        userEdit.Login = user.Login;
                        userEdit.Password = user.Password;

                        db.Entry(userEdit).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                user = new TbUser();
            }

            TbUserModel usrModel = new TbUserModel(user);
            return usrModel;
        }
    }
}
