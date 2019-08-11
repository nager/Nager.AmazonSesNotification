using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Bounce
    {
        /// <summary>
        /// The type of bounce (Undetermined, Permanent, Transient)
        /// </summary>
        public string BounceType { get; set; }
        /// <summary>
        /// The subtype of the bounce (Undetermined, General, NoEmail, Suppressed, MailboxFull, MessageTooLarge, ContentRejected, AttachmentRejected)
        /// </summary>
        public string BounceSubType { get; set; }
        public BouncedRecipient[] BouncedRecipients { get; set; }
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// A unique Id for the bounce.
        /// </summary>
        public string FeedbackId { get; set; }
        /// <summary>
        /// The IP address of the MTA to which Amazon SES attempted to deliver the mail.
        /// </summary>
        public string RemoteMtaIp { get; set; }
        /// <summary>
        /// The value of the MTA that attempted to perform the delivery, relay, or gateway operation described in the DSN. 
        /// </summary>
        public string ReportingMta { get; set; }
    }
}
