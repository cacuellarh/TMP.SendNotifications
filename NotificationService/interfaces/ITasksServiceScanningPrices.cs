using NotificationService.data.Models;
using NotificationService.dto.response;

namespace NotificationService.interfaces
{
    public interface ITasksServiceScanningPrices
    {
        public  Task<IReadOnlyList<ScanResponsePriceComparison>> MultiTaskPriceScanner(int? takeRegisters = 10, int numberRecordsScan = 10);
    }
}
