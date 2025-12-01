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
    public class ProductManager : IProductsServices
    {
        IProducts _products;
        public ProductManager(IProducts products)
        {
            _products = products;
        }

        public void Add(Products t)
        {
            _products.Add(t);
        }

        public decimal AverageCategoriesCount(string CategoryName)
        {
            return _products.AverageCategoriesCount(CategoryName);
        }

        public int CategoryNameProductsCount(string CategoryName)
        {
            var entity = _products.CategoryNameProductsCount(CategoryName);

            return entity;
        }

        public void Delete(Products t)
        {
            _products.Delete(t);
        }

        public Products GetById(int id)
        {
            var entity = _products.GetById(id);

            return entity;
        }

        public List<Products> GetList()
        {
            return _products.GetList();
        }

        public string HighPriceProduct()
        {
            return _products.HighPriceProduct();
        }

        public Products IncludeGetById(int id)
        {
           return _products.IncludeGetById(id);
        }

        public string LowPriceProduct()
        {
            return _products.LowPriceProduct();
        }

        public int ProductsCount()
        {
            var entity = _products.ProductsCount();

            return entity;
        }

        public void Update(Products t)
        {
            _products.Update(t);
        }

        public List<Products> WithCategoryList()
        {
            return _products.WithCategoryList();
        }
    }
}
