namespace SignalRWebUI.Dtos.Discount
{
    public class UpdateDiscount
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
