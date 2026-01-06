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
    public class BasketManager : IBasketServices
    {
        IBasket _basket;

        public BasketManager(IBasket basket)
        {
            _basket = basket;
        }
        public void Add(Basket t)
        {
            _basket.Add(t);
        }

        public void Delete(Basket t)
        {
            _basket.Delete(t);
        }

        public void DeleteBasketList(List<Basket> baskets)
        {
            _basket.DeleteBasketList(baskets);
        }

        public Basket GetById(int id)
        {
            return _basket.GetById(id);
        }

        public List<Basket> GetList()
        {
            return _basket.GetList();
        }

        public List<Basket> GetMenuTableBasket(int id)
        {
            return _basket.GetMenuTableBasket(id);
        }

        public void Update(Basket t)
        {
            _basket.Update(t);
        }
    }
}
