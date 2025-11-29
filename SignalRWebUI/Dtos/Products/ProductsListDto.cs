
namespace SignalRWebUI.Dtos.Products
{
    public class ProductsListDto
    {
        public int ProductsID { get; set; }
        public string ProductsName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }

        public int CategoryID { get; set; }
        public EntityLayer.Concrete.Category Category { get; set; }
    }
}
