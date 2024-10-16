using NotificationService.dto.response;

namespace NotificationService.validators
{
    public interface IJsonScanResponseValidator
    {
        public void ValideIfValueNotNull(JsonApiResponse response, string className, string methodName);

    }
}
