using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBasket:IGeneric<Basket>
    {
        public List<Basket> GetMenuTableBasket(int id);
        public void DeleteBasketList(List<Basket> baskets);
       


    }
}
