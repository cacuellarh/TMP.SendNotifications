using Serilog;

namespace NotificationService.handler
{
    public static class MainExceptionHandler
    {
        public static void ProcessFunction<TRequest>(Func<TRequest> callback)
        { 
            try
            {
                callback();         
            } 
            catch (Exception ex) 
            {
                Log.Error($"Ocurrio un error inesperado, detalles: {ex.Message}");
            }
        }
    }
}
