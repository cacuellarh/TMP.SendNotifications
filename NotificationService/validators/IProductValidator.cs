using NotificationService.data.Models;
using NotificationService.dto.response;

namespace NotificationService.validators
{
    public interface IProductValidator
    {
        void ValidateProductContainPrice(JsonApiResponse productPrice, string className, string methodName);

        public void ValidateIfPriceIsChange(ImageTrack lastImageScanned, Product currentProduct);

    }
}