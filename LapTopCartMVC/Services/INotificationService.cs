namespace LapTopCartMVC.Services
{
    public interface INotificationService
    {
        string SendEmail(string to, string subject, string body);
        string SendSms(string phoneNumber, string message);
        string SendPush(string deviceId, string message);
    }
}
