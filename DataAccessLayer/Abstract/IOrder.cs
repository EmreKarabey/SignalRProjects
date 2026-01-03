using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IOrder:IGeneric<Order>
    {
        public int OrderCount();
        public int ActiveOrderCount();
        public decimal LastOrderPrice();

        public decimal TodaySumCase();
    }
}
