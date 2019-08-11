namespace Nager.AmazonSesNotification.Model
{
    public class SesWebhook
    {
        /// <summary>
        /// Type of notification. (Bounce, Complaint, Delivery, or Received)
        /// </summary>
        public string NotificationType { get; set; }
        /// <summary>
        /// Contains information about the original mail
        /// </summary>
        public Mail Mail { get; set; }
    }
}
