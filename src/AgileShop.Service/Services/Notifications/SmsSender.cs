using AgileShop.Service.Dtos.Notifications;
using AgileShop.Service.Interfaces.Notifcations;

namespace AgileShop.Service.Services.Notifications;

public class SmsSender : ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage)
    {
        throw new NotImplementedException();
    }
}
