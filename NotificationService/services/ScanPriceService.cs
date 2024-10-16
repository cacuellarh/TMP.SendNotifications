using NotificationService.dto;
using NotificationService.dto.request;
using NotificationService.interfaces;
using NotificationService.helpers.json;
using NotificationService.data.Models;
using Serilog;
using NotificationService.exceptions;
using NotificationService.validators;

namespace NotificationService.services
{
    public class ScanPriceService : IScanPriceService
    {
        private readonly IHttpApiService _httpApiService;
        private readonly IJsonHelper _jsonHelper;
        private readonly IMap<ProductDto, Product> _map;
        private readonly IProductValidator _productValidator;
        private readonly IJsonScanResponseValidator _jsonScanResponseValidator;
        public ScanPriceService(IHttpApiService httpApiService,
            IJsonHelper jsonHelper,
            IMap<ProductDto, Product> map,
            IProductValidator productValidator,
            IJsonScanResponseValidator jsonScanResponseValidator
            )
        {
            _httpApiService = httpApiService;
            _jsonHelper = jsonHelper;
            _map = map;
            _productValidator = productValidator;
            _jsonScanResponseValidator = jsonScanResponseValidator;
        }
        public async Task<Product> ScanPriceAsync(string url, ScannUrlRequest request) 
        {

            try
            {
                var content = _jsonHelper.SerializeRequest(request);
                var jsonApiResponse = await _httpApiService.Post(url, content);

                // Validar que la respuesta no este null.
                _jsonScanResponseValidator.ValideIfValueNotNull(jsonApiResponse,nameof(ScanPriceService),nameof(ScanPriceAsync));

                // Validar que el producto dentro de la respuesta no sea null.
                _productValidator.ValidateProductContainPrice(jsonApiResponse,
                    nameof(ScanPriceService),
                    nameof(ScanPriceAsync));

                var productPrice = jsonApiResponse.value;

                var productMapped = _map.Map(productPrice);

                return productMapped;
            }
            catch (Exception ex)
            {
                var exception = new ScanPriceByApiException(
                    new BaseExceptionInformation(ex.Message, nameof(ImageTrackService), nameof(ScanPriceAsync))
                );
                Log.Error(ex.Message);

                throw;
            }
            
        }


    }
}
