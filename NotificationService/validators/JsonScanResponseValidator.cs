using NanisGuard;
using NanisGuard.src;
using NotificationService.dto.response;
using NotificationService.exceptions;

namespace NotificationService.validators
{
    public class JsonScanResponseValidator : IJsonScanResponseValidator
    {
        public void ValideIfValueNotNull(JsonApiResponse response, string className, string methodName)
        {
            NanisGuardV.validation.NotNull(response, customException: () => customException(className, methodName));
            NanisGuardV.validation.NotNull(response.value, customException: () => customException(className, methodName));
        }

        private Exception customException(string className, string methodName)
        {
            return new JsonApiResponseException($"Context : className:{className}, methodName{methodName}");
        }

    }
}
