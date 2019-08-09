namespace Nager.AmazonSesNotification.Model
{
    public class EmailComplaintWebhook : SesWebhook
    {
        public Complaint Complaint { get; set; }
    }
}
