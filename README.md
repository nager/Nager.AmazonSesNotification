# Nager.AmazonSesNotification
Amazon Simple Email Service Notification Processing


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
