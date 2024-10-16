using MediatR;
using NotificationService.data.Models;
using NotificationService.events.eventArgs;

namespace NotificationService.publisher
{
    public class PriceChangeEventPublisher : IPriceChangeEventPublisher
    {
        private readonly IMediator _mediator;
        
        public PriceChangeEventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void PublishPriceChangeEvent(ImageTrack lastImageScanned, Product currentProduct)
        {
            NotifyPriceChangeEvent notificationEvent = new NotifyPriceChangeEvent(lastImageScanned, currentProduct);
            _mediator.Publish(notificationEvent);
        }
    }
}
