using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Mail
    {
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string SourceArn { get; set; }
        public string SourceIp { get; set; }
        public string SendingAccountId { get; set; }
        public string MessageId { get; set; }
        public string[] Destination { get; set; }
        public bool HeadersTruncated { get; set; }
        public Header[] Headers { get; set; }
        public CommonHeaders CommonHeaders { get; set; }
    }
}
