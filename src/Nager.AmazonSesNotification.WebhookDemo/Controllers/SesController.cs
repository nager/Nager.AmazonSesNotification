using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nager.AmazonSesNotification.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nager.AmazonSesNotification.WebhookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesController : ControllerBase
    {
        [Route("SesNotification")]
        [HttpPost]
        public async Task<IActionResult> SesNotificationAsync()
        {
            var body = string.Empty;
            using (var reader = new StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            var notificationProcessor = new NotificationProcessor();
            var result = await notificationProcessor.ProcessNotificationAsync(body);

            //Your processing logic...
            if (result.NotificationType == "Bounce")
            {
                var webhook = result as EmailBounceWebhook;
                if (webhook.Bounce.BounceType.Equals("Permanent", StringComparison.OrdinalIgnoreCase))
                {

                }
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
