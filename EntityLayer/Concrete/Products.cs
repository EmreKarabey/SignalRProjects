using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Products
    {
        public int ProductsID { get; set; }
        public string ProductsName { get; set; }
        public string Description { get; set; }
        public decimal Priice { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }
    }
}
