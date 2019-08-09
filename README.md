# Nager.AmazonSesNotification
Amazon Simple Email Service Notification Processing

This project is a receiver for `Amazon SES` http/https Notifications. It can handle the default format or "Raw message delivery". The system also automatic subscribe to the sns webhook.

## Recommended implementation
```cs
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
    
    return StatusCode(StatusCodes.Status200OK);
 }
 ```


## Works only if "Raw message delivery" disabled
```cs
[Route("SesNotification")]
[HttpPost]
public async Task<IActionResult> SesNotificationAsync(SnsMessage snsMessage)
{  
    var notificationProcessor = new NotificationProcessor();
    var result = await notificationProcessor.ProcessNotificationAsync(snsMessage);
    
    //Your processing logic...
    
    return StatusCode(StatusCodes.Status200OK);
 }
```
