using Microsoft.Extensions.DependencyInjection;
using NotificationService;
using NotificationService.dto.request;
using NotificationService.exceptions;
using NotificationService.interfaces;

namespace Test.services
{
    [TestClass]
    public class ScanPrinceServiceTest
    {
        private ServiceProvider _provider;

        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            NotificationServiceRegistration.RegisterServiceNotification(services);
            _provider = services.BuildServiceProvider();
        }

        [TestMethod]
        [ExpectedException(typeof(ProductNotContainsPriceException))]
        public async Task ScanPriceWithInvalidUrlProduct()
        {
            var scan = _provider.GetService<IScanPriceService>();
            var url = "https://www.mercadolibre.com.co/";
            ScannUrlRequest request = new ScannUrlRequest(url);

            var result = await scan.ScanPriceAsync("http://localhost:5048/api/screen", request);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task ScanPriceWithValidUrlProduct()
        {
            var scan = _provider.GetService<IScanPriceService>();
            var url = "https://camiloandreskane5.wixsite.com/my-site/product-page/producto-prueba-1";
            ScannUrlRequest request = new ScannUrlRequest(url);

            var result = await scan.ScanPriceAsync("http://localhost:5048/api/screen", request);

            Assert.IsNull(result);
        }
        //[TestMethod]
        //[ExpectedException(typeof(ProductNotContainsPriceException))]
        //public async Task ScanPriceWithInvalidUrlProduct()
        //{
        //    var scan = _provider.GetService<IScanPriceService>();
        //    var url = "https://www.mercadolibre.com.co/";
        //    ScannUrlRequest request = new ScannUrlRequest(url);

        //    var result = await scan.ScanPriceAsync("http://localhost:5048/api/screen", request);

        //    Assert.IsNull(result);
        //}
    }
}
