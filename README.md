# Nager.AmazonSesNotification
Amazon Simple Email Service Notification Processing

This project is a receiver for `Amazon SES` http/https Notifications. It can handle the default format or "Raw message delivery". The system also automatic subscribe to the sns webhook.


```cs
[Route("SesNotification")]
[HttpPost]
public async Task<IActionResult> SesNotification()
{
    var body = string.Empty;
    using (var reader = new StreamReader(Request.Body))
    {
        body = await reader.ReadToEndAsync();
    }
    
    var notificationProcessor = new NotificationProcessor();
    var result = await notificationProcessor.ProcessNotificationAsync(body);
 }
```
