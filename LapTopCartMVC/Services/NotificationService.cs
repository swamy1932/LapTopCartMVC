namespace LapTopCartMVC.Services
{
    public class NotificationService : INotificationService
    {
        public string SendEmail(string to, string subject, string body)
        {
            return $"Email sent to {to} with subject '{subject}'";
        }

        public string SendSms(string phoneNumber, string message)
        {
            return $"SMS sent to {phoneNumber}: {message}";
        }

        public string SendPush(string deviceId, string message)
        {
            return $"Push notification sent to device {deviceId}: {message}";
        }
    }
}
