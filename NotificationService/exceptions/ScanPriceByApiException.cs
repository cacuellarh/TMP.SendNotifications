namespace NotificationService.exceptions
{
    public class ScanPriceByApiException : Exception
    {
        public ScanPriceByApiException(BaseExceptionInformation information) : base(information.MessageException())
        {
        }
    }
}
