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
    public class EFMoneyCase : GenericRepository<MoneyCase>, IMoneyCase
    {
        public decimal SumCase()
        {
            using var c = new DBContext();

            var entity = c.MoneyCases.Select(N=>N.TotalAmount).Sum();

            return entity;
        }
    }
}
