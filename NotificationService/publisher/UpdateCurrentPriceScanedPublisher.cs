using MediatR;
using NotificationService.events.eventArgs;

namespace NotificationService.publisher
{
    public class UpdateCurrentPriceScanedPublisher : IPublisher<UpdateCurrentPriceScanedEvent>
    {
        private readonly IMediator _mediator;

        public UpdateCurrentPriceScanedPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Publish(UpdateCurrentPriceScanedEvent e)
        {
            _mediator.Publish(e);
        }
    }
}
