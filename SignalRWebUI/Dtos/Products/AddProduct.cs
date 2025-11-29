using EntityLayer.Concrete;

namespace SignalRWebUI.Dtos.Products
{
    public class AddProduct
    {
        public string ProductsName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }

        public int CategoryID { get; set; }
        public EntityLayer.Concrete.Category Category { get; set; }

        public IFormFile Image { get; set; }
    }
}
