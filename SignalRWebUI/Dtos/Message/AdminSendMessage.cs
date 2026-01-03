namespace SignalRWebUI.Dtos.Message
{
    public class AdminSendMessage
    {
        public int Id { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiveMail { get; set; }
        public string MessageContent { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
    }
}
