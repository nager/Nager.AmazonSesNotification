using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Complaint
    {
        public ComplainedRecipient[] ComplainedRecipients { get; set; }
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// A unique Id associated with the complaint.
        /// </summary>
        public string FeedbackId { get; set; }
        /// <summary>
        /// This indicates the name and version of the system that generated the report.
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// abuse, auth-failure, fraud, not-spam, other, virus
        /// </summary>
        public string ComplaintFeedbackType { get; set; }
    }
}
