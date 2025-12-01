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
        public decimal AverageCategoriesCount(string CategoryName)
        {
            using var c = new DBContext();

            var entity = c.Products.Where(N => N.Category.CategoryName == CategoryName).Average(N => N.Price);

            return entity;
        }

        public int CategoryNameProductsCount(string CategoryName)
        {
            using var c = new DBContext();

            var entity = c.Products.Where(N => N.Category.CategoryName == CategoryName).Count();

            return entity;
        }

        public string HighPriceProduct()
        {
            using var c = new DBContext();

            var entity = c.Products.OrderByDescending(n => n.Price).Select(n => n.ProductsName).FirstOrDefault();

            return entity;
        }

        public Products IncludeGetById(int id)
        {
            using var c = new DBContext();

            var entity = c.Products.Where(N => N.ProductsID == id).Include(N => N.Category).FirstOrDefault();

            return entity;
        }

        public string LowPriceProduct()
        {
            using var c = new DBContext();

            var entity = c.Products.OrderBy(n => n.Price).Select(N => N.ProductsName).FirstOrDefault();

            return entity;
        }

        public int ProductsCount()
        {
            using var c = new DBContext();
            var entity = c.Products.Count();

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
