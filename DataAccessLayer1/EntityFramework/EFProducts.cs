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
    public class EFProducts : GenericRepository<Products>, IProducts
    {
        public Products IncludeGetById(int id)
        {
            using var c = new DBContext();

            var entity = c.Products.Where(N => N.ProductsID == id).Include(N => N.Category).FirstOrDefault();

            return entity;
        }

        public List<Products> WithCategoryList()
        {
            using var c = new DBContext();

            var list = c.Products.Include(n => n.Category).ToList();

            return list;
        }
    }
}
