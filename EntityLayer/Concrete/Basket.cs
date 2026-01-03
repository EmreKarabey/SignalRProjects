using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Basket
    {
        public int BasketID { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }
        public int Count { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
