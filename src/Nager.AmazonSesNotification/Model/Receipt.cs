using System;

namespace Nager.AmazonSesNotification.Model
{
    public class Receipt
    {
        public DateTime Timestamp { get; set; }
        public int ProcessingTimeMillis { get; set; }
        public string[] Recipients { get; set; }
        public SpamVerdict SpamVerdict { get; set; }
        public VirusVerdict VirusVerdict { get; set; }
        public SpfVerdict SpfVerdict { get; set; }
        public DkimVerdict DkimVerdict { get; set; }
        public DmarcVerdict DmarcVerdict { get; set; }
        public Action Action { get; set; }
    }
}
