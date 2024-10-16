using NanisGuard.src;
using NotificationService.dto.request;
using NotificationService.dto.response;
using NotificationService.exceptions;
using System.Text.Json;
using System.Text;
using NanisGuard;

namespace NotificationService.helpers.json
{
    public class JsonHelper : IJsonHelper
    {
        public StringContent SerializeRequest(object request)
        {
            try
            {
                var serializeContent = JsonSerializer.Serialize(request);
                return new StringContent(serializeContent, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                throw new SerializeRequestContentException($"{nameof(ScannUrlRequest)}", ex.Message);
            }
        }


        public JsonApiResponse DeserializeResponse(string serverResponse)
        {
            NanisGuardV.validation.NotNullOrEmpty(serverResponse);

            try
            {
                JsonApiResponse jsonResponse = JsonSerializer.Deserialize<JsonApiResponse>(serverResponse);
                NanisGuardV.validation.NotNull(jsonResponse);
                return jsonResponse;
            }
            catch (Exception ex)
            {
                throw new SerializeRequestContentException($"{nameof(ScannUrlRequest)}", ex.Message);
            }
        }

        public string SerializerObj<T>(object obj) where T : class
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
