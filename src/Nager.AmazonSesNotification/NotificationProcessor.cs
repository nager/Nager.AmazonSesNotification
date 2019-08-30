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
            if (await this.SubscribeSnsWebhookAsync(json))
            {
                return null;
            }

            #region Check if "Raw message delivery" active

            var snsMessage = JsonConvert.DeserializeObject<SnsMessage>(json);
            if (snsMessage != null && snsMessage.Type != null)
            {
                if (snsMessage.Type.Equals("Notification", StringComparison.OrdinalIgnoreCase))
                {
                    return this.Deserialize(snsMessage.Message);
                }

                return null;
            }

            #endregion

            return this.Deserialize(json);
        }

        public async Task<SesWebhook> ProcessNotificationAsync(SnsMessage snsMessage)
        {
            if (await this.SubscribeSnsWebhookAsync(snsMessage))
            {
                return null;
            }

            if (snsMessage != null && snsMessage.Type != null)
            {
                if (snsMessage.Type.Equals("Notification", StringComparison.OrdinalIgnoreCase))
                {
                    return this.Deserialize(snsMessage.Message);
                }

                return null;
            }

            return null;
        }

        private SesWebhook Deserialize(string json)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                    //MissingMemberHandling = MissingMemberHandling.Error
                };

                var item = JsonConvert.DeserializeObject<SesWebhook>(json);
                switch (item.NotificationType)
                {
                    case "Received":
                        return JsonConvert.DeserializeObject<EmailReceivedWebhook>(json, settings);
                    case "Bounce":
                        return JsonConvert.DeserializeObject<EmailBounceWebhook>(json, settings);
                    case "Complaint":
                        return JsonConvert.DeserializeObject<EmailComplaintWebhook>(json, settings);
                    case "Delivery":
                        return JsonConvert.DeserializeObject<EmailDeliveredWebhook>(json, settings);
                }
            }
            catch (Exception exception)
            {
                
            }

            return null;
        }

        private async Task<bool> SubscribeSnsWebhookAsync(string json)
        {
            var snsMessage = JsonConvert.DeserializeObject<SnsMessage>(json);
            if (snsMessage == null)
            {
                return false;
            }

            return await this.SubscribeSnsWebhookAsync(snsMessage);
        }

        private async Task<bool> SubscribeSnsWebhookAsync(SnsMessage snsMessage)
        {
            if (snsMessage.Type == null)
            {
                return false;
            }

            if (!snsMessage.Type.Equals("SubscriptionConfirmation", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (string.IsNullOrEmpty(snsMessage.SubscribeURL))
            {
                //this._logger.LogError($"No subcribe url available {json}");
                return false;
            }

            using (var httpClient = new HttpClient())
            {
                await httpClient.GetAsync(snsMessage.SubscribeURL);
                return true;
            }
        }
    }
}
