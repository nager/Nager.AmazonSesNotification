namespace Nager.AmazonSesNotification.Model
{
    public class EmailBounceWebhook : SesWebhook
    {
        public Bounce Bounce { get; set; }
    }
}
