using MediatR;
using NotificationService.data.Models;

namespace NotificationService.events.eventArgs
{
    public class NotifyPriceChangeEvent : INotification
    {
        public NotifyPriceChangeEvent(ImageTrack lastPrice, Product productCurrentPrice)
        {
            this.lastPrice = lastPrice;
            this.productCurrentPrice = productCurrentPrice;
        }

        public ImageTrack lastPrice { get; private set; }
        public Product productCurrentPrice { get; private set; }
    }
}
