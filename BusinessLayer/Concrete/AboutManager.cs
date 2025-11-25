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
    public class AboutManager : IAboutServices
    {
        IAbout _about;

        public AboutManager(IAbout about)
        {
            _about = about;
        }
        public void Add(About t)
        {
            _about.Add(t);
        }

        public void Delete(About t)
        {
            _about.Delete(t);
        }

        public About GetById(int id)
        {
            return _about.GetById(id);
        }

        public void GetList()
        {
            _about.GetList();
        }

        public void Update(About t)
        {
            _about.Update(t);
        }
    }
}
