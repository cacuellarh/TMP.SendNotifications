namespace NotificationService.dto.response
{
    public class JsonApiResponse
    {
        public bool isSuccess { get; set; }
        public string errorMessage { get; set; }
        public int codeStatusOperation { get; set; }
        public ProductDto value { get; set; }
    }
}
