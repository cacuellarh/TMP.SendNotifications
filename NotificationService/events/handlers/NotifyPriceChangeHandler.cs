using MediatR;
using NotificationService.events.eventArgs;
using NotificationService.services;

namespace NotificationService.events.handlers
{
    public class NotifyPriceChangeHandler : INotificationHandler<NotifyPriceChangeEvent>
    {
        private readonly IEmailServices _emailServices;

        public NotifyPriceChangeHandler(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public Task Handle(NotifyPriceChangeEvent notification, CancellationToken cancellationToken)
        {
            _emailServices.SendEmail(notification);
            return Task.CompletedTask;
        }
    }
}
