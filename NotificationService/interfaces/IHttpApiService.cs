using NotificationService.dto.response;

namespace NotificationService.interfaces
{
    public interface IHttpApiService
    {
        public Task<JsonApiResponse> Post(string url, StringContent? content);
    }
}
