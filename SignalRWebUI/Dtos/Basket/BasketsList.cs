using EntityLayer.Concrete;

namespace SignalRWebUI.Dtos.Basket
{
    public class BasketsList
    {
        public int BasketID { get; set; }

        public EntityLayer.Concrete.Products Products { get; set; } 
        public int Count { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public EntityLayer.Concrete.MenuTable MenuTable { get; set; }
    }
}
