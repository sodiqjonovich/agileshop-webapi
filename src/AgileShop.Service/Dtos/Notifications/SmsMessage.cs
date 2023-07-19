namespace AgileShop.Service.Dtos.Notifications;

public class SmsMessage
{
    public string PhoneNumber { get; set; } = String.Empty;

    public string Content { get; set; } = String.Empty;
}
