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
    public class OrderDetailsManager : IOrderDetailsServices
    {
        IOrderDetails _orderDetails;

        public OrderDetailsManager(IOrderDetails orderDetails)
        {
            _orderDetails = orderDetails;
        }
        public void Add(OrderDetails t)
        {
            _orderDetails.Add(t);
        }

        public void Delete(OrderDetails t)
        {
            _orderDetails.Delete(t);
        }

        public OrderDetails GetById(int id)
        {
            return _orderDetails.GetById(id);
        }

        public List<OrderDetails> GetList()
        {
            return _orderDetails.GetList(); 
        }

        public void Update(OrderDetails t)
        {
            _orderDetails.Update(t);
        }
    }
}
