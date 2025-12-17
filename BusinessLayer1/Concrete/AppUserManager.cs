using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserServices
    {
        IAppUser _appUser;

        public AppUserManager(IAppUser appUser)
        {
            _appUser = appUser;
        }
        public void Add(AppUser t)
        {
            _appUser.Add(t);
        }

        public void Delete(AppUser t)
        {
            _appUser.Delete(t);
        }

        public AppUser GetById(int id)
        {
            return _appUser.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _appUser.GetList();
        }

        public void Update(AppUser t)
        {
            _appUser.Update(t);
        }
    }
}
