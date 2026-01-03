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
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLayer.EntityFramework
{
    public class EFProducts : GenericRepository<Products>, IProducts
    {
        private readonly DBContext c;

        public EFProducts(DBContext c) : base(c)
        {
            this.c = c;
        }

        public decimal AverageCategoriesCount(string CategoryName)
        {
            var entity = c.Products.Where(N => N.Category.CategoryName == CategoryName).Average(N => N.Price);

            return entity;
        }

        public decimal AveragePrice()
        {
            var averagePrice = Convert.ToDecimal(c.Products.Average(n => n.Price).ToString("0.00"));

            return averagePrice;
        }

        public int CategoryNameProductsCount(string CategoryName)
        {
            var entity = c.Products.Where(N => N.Category.CategoryName == CategoryName).Count();

            return entity;
        }

        public string HighPriceProduct()
        {
            var entity = c.Products.OrderByDescending(n => n.Price).Select(n => n.ProductsName).FirstOrDefault();

            return entity;
        }

        public Products IncludeGetById(int id)
        {
            var entity = c.Products.Where(N => N.ProductsID == id).Include(N => N.Category).FirstOrDefault();

            return entity;
        }

        public string LowPriceProduct()
        {
            var entity = c.Products.OrderBy(n => n.Price).Select(N => N.ProductsName).FirstOrDefault();

            return entity;
        }

        public int ProductsCount()
        {
            var entity = c.Products.Count();

            return entity;
        }

        public List<Products> WithCategoryList()
        {
            var list = c.Products.Include(n => n.Category).ToList();

            return list;
        }
    }
}
