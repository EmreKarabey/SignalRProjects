using EntityLayer.Concrete;

namespace SignalRWebUI.Dtos.Basket
{
    public class AddBasket
    {
        public int ProductsID { get; set; }
        public int Count { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int MenuTableID { get; set; }
    }
}
