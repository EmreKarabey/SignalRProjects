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
    public class OrderManager : IOrderService
    {
        IOrder _order;

        public OrderManager(IOrder order)
        {
            _order = order;
        }

        public int ActiveOrderCount()
        {
            return _order.ActiveOrderCount();
        }

        public void Add(Order t)
        {
            _order.Add(t);
        }

        public void Delete(Order t)
        {
            _order.Delete(t);
        }

        public Order GetById(int id)
        {
            return _order.GetById(id);
        }

        public List<Order> GetList()
        {
            return _order.GetList();
        }

        public decimal LastOrderPrice()
        {
            return _order.LastOrderPrice();
        }

        public int OrderCount()
        {
            return _order.OrderCount();
        }

        public decimal TodaySumCase()
        {
            return _order.TodaySumCase();
        }

        public void Update(Order t)
        {
            _order.Update(t);
        }
    }
}
