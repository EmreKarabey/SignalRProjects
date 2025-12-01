using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFOrder : GenericRepository<Order>, IOrder
    {
        public int ActiveOrderCount()
        {
            using var c = new DBContext();

            var entity = c.Orders.Where(N => N.OrderStatus == true).Count();

            return entity;
        }

        public decimal LastOrderPrice()
        {
            using var c = new DBContext();

            var entity = c.Orders.OrderByDescending(n => n.Date).Select(n => n.TotalPrice).FirstOrDefault();

            return entity;
        }

        public int OrderCount()
        {
            using var c = new DBContext();

            var entity = c.Orders.Count();

            return entity;
        }

        public decimal TodaySumCase()
        {
            using var c = new DBContext();

            var entity = c.Orders.Where(N => N.Date.Date == DateTime.Now.Date).Sum(N => N.TotalPrice);

            return entity;
        }
    }
}
