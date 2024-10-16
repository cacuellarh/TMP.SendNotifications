
using Microsoft.Extensions.DependencyInjection;

using NotificationService;
using NotificationService.interfaces;


namespace Test.Data
{
    [TestClass]
    public class ImageTrackServiceTest
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
        public async Task GetRecords_shouldTrue()
        {
            var service = _provider.GetService<IImageTrackService>();

            var result = await service.GetImageTracksAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); // Ajusta el valor según la expectativa
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_provider != null)
            {
                _provider.Dispose();
            }
        }
    }
}