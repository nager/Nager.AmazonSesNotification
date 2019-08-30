namespace Nager.AmazonSesNotification.Model
{
    public class CommonHeaders
    {
        public string ReturnPath { get; set; }
        public string[] From { get; set; }
        public string[] ReplyTo { get; set; }
        public string Date { get; set; }
        public string[] To { get; set; }
        public string MessageId { get; set; }
        public string Subject { get; set; }
    }
}
