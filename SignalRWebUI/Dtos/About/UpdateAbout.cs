namespace SignalRWebUI.Dtos.About
{
    public class UpdateAbout
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
