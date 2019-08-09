namespace Nager.AmazonSesNotification.Model
{
    public class BouncedRecipient
    {
        public string EmailAddress { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string DiagnosticCode { get; set; }
    }
}
