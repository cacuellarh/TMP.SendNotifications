using NotificationService.dto.request;
using NotificationService.dto.response;

namespace NotificationService.helpers.json
{
    public interface IJsonHelper
    {
        public StringContent SerializeRequest(object request);

        public JsonApiResponse DeserializeResponse(string serverResponse);

        public string SerializerObj<T>(object obj) where T : class;
    }
}
