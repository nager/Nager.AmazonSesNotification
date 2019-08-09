using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Bounce
    {
        public string BounceType { get; set; }
        public string BounceSubType { get; set; }
        public BouncedRecipient[] BouncedRecipients { get; set; }
        public DateTime Timestamp { get; set; }
        public string FeedbackId { get; set; }
        public string RemoteMtaIp { get; set; }
        public string ReportingMta { get; set; }
    }
}
