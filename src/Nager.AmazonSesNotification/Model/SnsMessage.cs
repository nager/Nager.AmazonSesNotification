using System;

namespace Nager.AmazonSesNotification.Model
{
    public class SnsMessage
    {
        public string Type { get; set; }
        public string MessageId { get; set; }
        public string Token { get; set; }
        public string TopicArn { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public string SignatureVersion { get; set; }
        public string Signature { get; set; }

        public string SigningCertUrl { get; set; }

        public string SubscribeURL { get; set; }
        public string UnsubscribeUrl { get; set; }
    }
}
