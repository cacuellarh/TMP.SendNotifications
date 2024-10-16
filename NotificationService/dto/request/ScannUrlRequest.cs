namespace NotificationService.dto.request
{
    public class ScannUrlRequest
    {
        public ScannUrlRequest(string url)
        {
            Url = url;
        }

        public string Url { get; private set; }
    }
}
