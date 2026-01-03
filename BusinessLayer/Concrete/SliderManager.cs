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
    public class SliderManager : ISliderServices
    {
        ISlider _slider;

        public SliderManager(ISlider slider)
        {
            _slider = slider;
        }
        public void Add(Slider t)
        {
            _slider.Add(t);
        }

        public void Delete(Slider t)
        {
            _slider.Delete(t);
        }

        public Slider GetById(int id)
        {
            return _slider.GetById(id);
        }

        public List<Slider> GetList()
        {
            return _slider.GetList();
        }

        public void Update(Slider t)
        {
            _slider.Update(t);
        }
    }
}
