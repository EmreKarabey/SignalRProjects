namespace SignalRWebUI.Dtos.Discount
{
    public class AddDiscount
    {
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
