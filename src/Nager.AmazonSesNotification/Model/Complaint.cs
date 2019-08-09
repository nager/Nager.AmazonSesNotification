using System;
using System.Collections.Generic;
using System.Text;

namespace Nager.AmazonSesNotification.Model
{
    public class Complaint
    {
        public ComplainedRecipient[] ComplainedRecipients { get; set; }
        public DateTime Timestamp { get; set; }
        public string FeedbackId { get; set; }
        public string UserAgent { get; set; }
        public string ComplaintFeedbackType { get; set; }
    }
}
