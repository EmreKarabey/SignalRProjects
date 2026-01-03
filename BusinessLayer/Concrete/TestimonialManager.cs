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
    public class TestimonialManager : ITestimonialServices
    {
        ITestimonial _testimonial;

        public TestimonialManager(ITestimonial testimonial)
        {
            _testimonial = testimonial;
        }
        public void Add(Testimonial t)
        {
            _testimonial.Add(t);
        }

        public void Delete(Testimonial t)
        {
            _testimonial.Delete(t);
        }

        public Testimonial GetById(int id)
        {
            return _testimonial.GetById(id);
        }

        public List<Testimonial> GetList()
        {
            return _testimonial.GetList();
        }

        public void Update(Testimonial t)
        {
            _testimonial.Update(t);
        }
    }
}
