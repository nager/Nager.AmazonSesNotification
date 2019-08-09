using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.AmazonSesNotification.Model;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Nager.AmazonSesNotification.UnitTest
{
    [TestClass]
    public class ParsingTest
    {
        [TestMethod]
        [DeploymentItem(@"Notifications\Notifications.json")]
        [DeploymentItem(@"Notifications\RawMessageDelivery\Received.json")]
        [DeploymentItem(@"Notifications\RawMessageDelivery\Bounce.json")]
        [DeploymentItem(@"Notifications\RawMessageDelivery\Delivery.json")]
        [DeploymentItem(@"Notifications\RawMessageDelivery\Complaint.json")]
        public async Task ProcessReceivedTest()
        {
            await this.CheckAsync("Received.json");
            await this.CheckAsync("Bounce.json");
            await this.CheckAsync("Delivery.json");
            await this.CheckAsync("Complaint.json");
        }

        private async Task CheckAsync(string file)
        {
            var jsonNotification = File.ReadAllText(@"Notifications\Notification.json");
            var jsonDetails = File.ReadAllText($@"Notifications\RawMessageDelivery\{file}");

            var minimized = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(jsonDetails), Formatting.None);
            var notification = JsonConvert.DeserializeObject<SnsMessage>(jsonNotification);
            notification.Message = minimized;
            var json = JsonConvert.SerializeObject(notification, Formatting.Indented);

            var item = await new NotificationProcessor().ProcessNotificationAsync(json);
            Assert.IsNotNull(item);

            item = await new NotificationProcessor().ProcessNotificationAsync(jsonDetails);
            Assert.IsNotNull(item);
        }
    }
}
