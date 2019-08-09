namespace Nager.AmazonSesNotification.Model
{
    public class EmailReceivedWebhook : SesWebhook
    {
        public Receipt Receipt { get; set; }
        public string Content { get; set; }
    }
}
