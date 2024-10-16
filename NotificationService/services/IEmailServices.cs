using NotificationService.events.eventArgs;

namespace NotificationService.services
{
    public interface IEmailServices
    {
        public void SendEmail(NotifyPriceChangeEvent priceScanInfo);
    }
}