namespace Nager.AmazonSesNotification.Model
{
    public class EmailDeliveredWebhook : SesWebhook
    {
        public Delivery Delivery { get; set; }
    }
}
