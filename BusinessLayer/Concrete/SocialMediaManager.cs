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
    public class SocialMediaManager : ISocialMediaServices
    {
        ISocialMedia _socialMedia;

        public SocialMediaManager(ISocialMedia socialMedia)
        {
            _socialMedia = socialMedia;
        }
        public void Add(SocialMedia t)
        {
            _socialMedia.Add(t);
        }

        public void Delete(SocialMedia t)
        {
            _socialMedia.Delete(t);
        }

        public SocialMedia GetById(int id)
        {
            return _socialMedia.GetById(id);
        }

        public List<SocialMedia> GetList()
        {
           return _socialMedia.GetList();
        }

        public void Update(SocialMedia t)
        {
            _socialMedia.Update(t);
        }
    }
}
