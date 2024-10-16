using Serilog;

namespace NotificationService
{
    public static class LoggerBuildConfiguration
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"/usr/log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("La aplicación ha iniciado.");
        }
    }
}
