using NotificationService.data.Models;

namespace NotificationService.publisher
{
    public interface IPriceChangeEventPublisher
    {
        public void PublishPriceChangeEvent(ImageTrack lastImageScanned, Product currentProduct);
    }
}
