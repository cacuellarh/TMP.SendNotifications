using NanisGuard.src;
using NotificationService.exceptions;
using NanisGuard;
using NotificationService.data.Models;
using NotificationService.publisher;
using NotificationService.dto.response;
using NotificationService.helpers.json;
using NotificationService.events.eventArgs;


namespace NotificationService.validators
{
    public class ProductValidator : IProductValidator
    {
        private readonly IPriceChangeEventPublisher _publiser;
        private readonly IJsonHelper _jsonHelper;
        private readonly IPublisher<UpdateCurrentPriceScanedEvent> _publisherUpdatePrice;
        public ProductValidator(IPriceChangeEventPublisher publiser,
            IJsonHelper jsonHelper,
            IPublisher<UpdateCurrentPriceScanedEvent> publisherUpdatePrice
            )
        {
            _publiser = publiser;
            _jsonHelper = jsonHelper;
            _publisherUpdatePrice = publisherUpdatePrice;
        }

        public void ValidateIfPriceIsChange(ImageTrack lastImageScanned, Product currentProduct)
        {
            NanisGuardV.validation.NotNull(lastImageScanned.Product.PrecioActualEscaneado,
                nameof(lastImageScanned.Product.PrecioActualEscaneado));

            NanisGuardV.validation.NotNull(currentProduct.Precio, nameof(currentProduct.Precio));

            var lastPrice = lastImageScanned.Product.PrecioActualEscaneado;
            var currentPrice = currentProduct.Precio;

            if (lastPrice != currentPrice)
            {
                _publiser.PublishPriceChangeEvent(lastImageScanned, currentProduct);
                _publisherUpdatePrice.Publish(new UpdateCurrentPriceScanedEvent(lastImageScanned.Product, currentProduct));
            }
        }
        public void ValidateProductContainPrice(JsonApiResponse productPrice,string className,string methodName)
        {
            var jsonResponseApinformation = _jsonHelper.SerializerObj<JsonApiResponse>(productPrice);
            NanisGuardV.validation
                .NotNull(productPrice, nameof(productPrice),
                   customException: () => new ProductNotContainsPriceException(jsonResponseApinformation, className, methodName));
        }


    }
}
