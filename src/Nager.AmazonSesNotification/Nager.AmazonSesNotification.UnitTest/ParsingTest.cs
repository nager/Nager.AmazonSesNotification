using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace Nager.AmazonSesNotification.UnitTest
{
    [TestClass]
    public class ParsingTest
    {
        [TestMethod]
        [DeploymentItem(@"Notifications\Received.json")]
        public async Task ProcessReceivedTest()
        {
            var json = File.ReadAllText(@"Notifications\Received.json");
            var item = await new NotificationProcessor().ProcessNotificationAsync(json);

            Assert.IsNotNull(item);
        }

        [TestMethod]
        [DeploymentItem(@"Notifications\RawMessageDelivery\Received.json")]
        public async Task ProcessRawReceivedTest()
        {
            var json = File.ReadAllText(@"Notifications\RawMessageDelivery\Received.json");
            var item = await new NotificationProcessor().ProcessNotificationAsync(json);

            Assert.IsNotNull(item);
        }
    }
}
