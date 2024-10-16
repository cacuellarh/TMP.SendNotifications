using MediatR;
using NotificationService.data.Models;
using NotificationService.interfaces;

namespace NotificationService.events.eventArgs
{
    public class UpdateCurrentPriceScanedEvent : IPublisherEvent, INotification
    {
        public UpdateCurrentPriceScanedEvent(Product productDb, Product currentProductScaned)
        {
            ProductDb = productDb;
            CurrentProductScaned = currentProductScaned;
        }

        public Product ProductDb { get; private set; }
        public Product CurrentProductScaned { get; private set; }
    }
}
