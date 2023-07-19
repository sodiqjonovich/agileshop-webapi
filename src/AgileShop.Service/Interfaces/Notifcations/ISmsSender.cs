using AgileShop.Service.Dtos.Notifications;

namespace AgileShop.Service.Interfaces.Notifcations;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
