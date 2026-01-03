using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IProductsServices:IGenericServices<Products>
    {
        public List<Products> WithCategoryList();

        public Products IncludeGetById(int id);

        public int ProductsCount();

        public int CategoryNameProductsCount(string CategoryName);

        public decimal AverageCategoriesCount(string CategoryName);

        public string LowPriceProduct();
        public string HighPriceProduct();

        public decimal AveragePrice();
    }
}
