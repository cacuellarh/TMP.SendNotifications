using NotificationService.dto.request;
using NotificationService.interfaces;
using Serilog;
using NotificationService.dto.response;
using NotificationService.validators;
using Microsoft.Extensions.Configuration;

namespace NotificationService.services
{
    public class TasksServiceScanningPrices : ITasksServiceScanningPrices
    {
        private readonly IImageTrackService _imageTrackService;
        private readonly IScanPriceService _scanPriceService;
        private readonly IProductValidator _productValidator;
        private readonly string apiPath;
        private List<ScanResponsePriceComparison> _imagePricesChanged = new List<ScanResponsePriceComparison>();
        public TasksServiceScanningPrices(IImageTrackService imageTrackService,
            IScanPriceService scanPriceService,
            IProductValidator productValidator,
            IConfiguration configuration
            )
        {
            _imageTrackService = imageTrackService;
            _scanPriceService = scanPriceService;
            _productValidator = productValidator;
            apiPath = configuration.GetConnectionString("ApiUrl")!;
        }
        public async Task<IReadOnlyList<ScanResponsePriceComparison>> MultiTaskPriceScanner(int? takeRegisters = 10, int numberRecordsScan = 10)
        {
            var semaphore = new SemaphoreSlim(10);
            var imageTrackRecords = await _imageTrackService.GetImageTracksAsync();
            var takeRecords = imageTrackRecords.Take(numberRecordsScan);

            var tasks = takeRecords.Select(async imageTrackLastScan =>
            {
                Console.WriteLine("Iniciando hilo de tareas.");
                await semaphore.WaitAsync();
                try
                {
                    ScannUrlRequest request = new ScannUrlRequest(imageTrackLastScan.Url);
                    var currentProductScan = await _scanPriceService.ScanPriceAsync(apiPath, request);
                    _productValidator.ValidateIfPriceIsChange(imageTrackLastScan, currentProductScan);

                }
                catch (Exception ex)
                {
                    Log.Error($"Error al intentar crear tareas de validacion ,ex.Message");
                }
                finally
                {
                    semaphore.Release();
                }
                
            });

            await Task.WhenAll(tasks);

            return _imagePricesChanged.AsReadOnly();
        }
        
    }
}
