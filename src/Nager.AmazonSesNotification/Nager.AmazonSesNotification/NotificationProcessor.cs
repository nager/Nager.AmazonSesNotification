using Nager.AmazonSesNotification.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nager.AmazonSesNotification
{
    public class NotificationProcessor
    {
        public async Task<SesWebhook> ProcessNotificationAsync(string json)
        {
            await this.SubscribeSnsWebhookAsync(json);

            #region Check if "Raw message delivery" active

            var snsMessage = JsonConvert.DeserializeObject<SnsMessage>(json);
            if (snsMessage != null && snsMessage.Type != null)
            {
                if (snsMessage.Type.Equals("Notification", StringComparison.OrdinalIgnoreCase))
                {
                    var item = JsonConvert.DeserializeObject<SesWebhook>(snsMessage.Message);
                    return item;
                }

                return null;
            }

            #endregion

            var item1 = JsonConvert.DeserializeObject<SesWebhook>(json);
            return item1;
        }


        private async Task SubscribeSnsWebhookAsync(string json)
        {
            var subscriptionConfirmation = JsonConvert.DeserializeObject<SnsMessage>(json);
            if (subscriptionConfirmation == null)
            {
                return;
            }

            if (subscriptionConfirmation.Type == null)
            {
                return;
            }

            if (!subscriptionConfirmation.Type.Equals("SubscriptionConfirmation", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (string.IsNullOrEmpty(subscriptionConfirmation.SubscribeURL))
            {
                //this._logger.LogError($"No subcribe url available {json}");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                await httpClient.GetAsync(subscriptionConfirmation.SubscribeURL);
            }
        }
    }
}
