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
    public class DiscountManager : IDiscountServices
    {
        IDiscount _discount;

        public DiscountManager(IDiscount discount)
        {
            _discount = discount;
        }
        public void Add(Discount t)
        {
            _discount.Add(t);
        }

        public void Delete(Discount t)
        {
            _discount.Delete(t);
        }

        public Discount GetById(int id)
        {
            return _discount.GetById(id);
        }

        public List<Discount> GetList()
        {
            return _discount.GetList();
        }

        public void Update(Discount t)
        {
            _discount.Update(t);
        }
    }
}
