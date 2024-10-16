using NotificationService.dto.request;
using NotificationService.dto;
using NotificationService.data.Models;

namespace NotificationService.interfaces
{
    public interface IScanPriceService
    {
        public  Task<Product> ScanPriceAsync(string url, ScannUrlRequest request);
    }
}
