# Nager.AmazonSesNotification
Amazon Simple Email Service Notification Processing

This project is a receiver for `Amazon SES` http/https Notifications. It can handle the default format or "Raw message delivery". The system also automatic subscribe to the sns webhook.

## nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.AmazonSesNotification)
```
PM> install-package Nager.AmazonSesNotification
```

## Documentation
 - [SES Documentation](https://docs.aws.amazon.com/ses/latest/DeveloperGuide/notifications-via-email.html) 
 - [Testing Email Sending in Amazon SES](https://docs.aws.amazon.com/ses/latest/DeveloperGuide/mailbox-simulator.html)

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
