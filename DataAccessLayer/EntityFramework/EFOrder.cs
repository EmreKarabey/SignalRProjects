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
        private readonly DBContext c;

        public EFOrder(DBContext c) : base(c)
        {
            this.c = c;
        }
        public int ActiveOrderCount()
        {
            var entity = c.Orders.Where(N => N.OrderStatus == true).Count();

            return entity;
        }

        public decimal LastOrderPrice()
        {
            var entity = c.Orders.OrderByDescending(n => n.Date).Select(n => n.TotalPrice).FirstOrDefault();

            return entity;
        }

        public int OrderCount()
        {
            var entity = c.Orders.Count();

            return entity;
        }

        public decimal TodaySumCase()
        {
            var entity = c.Orders.Where(N => N.Date.Date == DateTime.Now.Date).Sum(N => N.TotalPrice);

            return entity;
        }
    }
}
