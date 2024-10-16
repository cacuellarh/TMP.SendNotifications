using NotificationService.data.Models;

namespace NotificationService.dto.response
{
    public record ScanResponsePriceComparison(ImageTrack lastPrice, Product productCurrentPrice)
    {
    }
}
