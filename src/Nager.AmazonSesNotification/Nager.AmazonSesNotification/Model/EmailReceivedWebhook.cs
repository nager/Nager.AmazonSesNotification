namespace Nager.AmazonSesNotification.Model
{
    public class EmailReceivedWebhook : SesWebhook
    {
        public Mail Mail { get; set; }
        public Receipt Receipt { get; set; }
        public string Content { get; set; }
    }
}
