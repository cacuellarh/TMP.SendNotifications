using Microsoft.Extensions.DependencyInjection;
using NotificationService;
using NotificationService.handler;
using NotificationService.interfaces;
using Serilog;

class Program
{
    private static Timer _timer;
    private static ServiceProvider _provider;

    static async Task Main(string[] args)
    {
        _provider = StartServiceProviders();
        LoggerBuildConfiguration.Configure();

        MainExceptionHandler.ProcessFunction<Unit>(() => {
            _timer = new Timer(ExecuteTask, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Unit.Value;
        });
        

        Console.WriteLine("Presiona Enter para salir.");
        Console.ReadLine();
    }

    private static ServiceProvider StartServiceProviders()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        return services.BuildServiceProvider();
    }

    private static async void ExecuteTask(object state)
    {
        ITasksServiceScanningPrices scanPricesTasks = _provider.GetRequiredService<ITasksServiceScanningPrices>();
        var result = await scanPricesTasks.MultiTaskPriceScanner(numberRecordsScan: 5);
        Log.Information("Escaneo de precios completado.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Registro de servicios de NotificationService
        NotificationServiceRegistration.RegisterServiceNotification(services);
    }
}