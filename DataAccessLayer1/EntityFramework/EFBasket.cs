using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFBasket : GenericRepository<Basket>, IBasket
    {
        

        public List<Basket> GetMenuTableBasket(int id)
        {
            using var c = new DBContext();

            var list = c.Baskets.Include(N=>N.Products).Where(N => N.MenuTable.MenuTableID == id).ToList();

            return list;
        }

        
    }
}
