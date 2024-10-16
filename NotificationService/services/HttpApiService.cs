using NotificationService.dto.response;
using NotificationService.helpers.json;
using NotificationService.interfaces;
using Serilog;

namespace NotificationService.services
{
    internal class HttpApiService : IHttpApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonHelper _jsonHelper;
        public HttpApiService(IJsonHelper jsonHelper)
        {
            _httpClient = new HttpClient();
            _jsonHelper = jsonHelper;
        }

        public async Task<JsonApiResponse> Post(string url, StringContent? content)
        {
            try
            { 
                var response = await _httpClient.PostAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();
                return _jsonHelper.DeserializeResponse(responseBody);
            }
            catch(Exception ex) 
            {
                Log.Error($"Error HTTP al procesar la solicitud: {ex.Message}");
                throw new HttpRequestException($"Error HTTP al procesar la solicitud: {ex.Message}");
            }

            
        }
    }
}
