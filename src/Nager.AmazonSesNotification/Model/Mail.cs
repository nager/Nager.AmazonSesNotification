using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Mail
    {
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        /// <summary>
        /// The Amazon Resource Name (ARN) of the identity that was used to send the mail.
        /// </summary>
        public string SourceArn { get; set; }
        /// <summary>
        /// The originating public IP address of the client that performed the mail sending request to Amazon SES.
        /// </summary>
        public string SourceIp { get; set; }
        public string SendingAccountId { get; set; }
        /// <summary>
        /// A unique Id that Amazon SES assigned to the message.
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// A list of email addresses that were recipients of the original mail.
        /// </summary>
        public string[] Destination { get; set; }
        public bool HeadersTruncated { get; set; }
        public Header[] Headers { get; set; }
        /// <summary>
        /// Include the headers from the original mail.
        /// </summary>
        public CommonHeaders CommonHeaders { get; set; }
    }
}
