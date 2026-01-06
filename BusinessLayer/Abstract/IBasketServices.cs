using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBasketServices:IGenericServices<Basket>
    {
        public List<Basket> GetMenuTableBasket(int id);

        public void DeleteBasketList(List<Basket> baskets);
    }
}
