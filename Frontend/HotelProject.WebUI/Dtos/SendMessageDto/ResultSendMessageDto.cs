namespace HotelProject.WebUI.Dtos.SendMessageDto
{
    public class ResultSendMessageDto
    {
        public int SendMessageId { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string SenderName { get; set; } = default!;
        public string SenderMail { get; set; } = default!;
        public string ReceiverName { get; set; } = default!;
        public string ReceiverMail { get; set; } = default!;
        public DateTime Date { get; set; }
    }
}