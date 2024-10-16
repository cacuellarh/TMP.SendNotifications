using System.Runtime.Serialization;

namespace NotificationService.exceptions
{
    public class ImageTrackNoContainsAnyException : Exception
    {
        public ImageTrackNoContainsAnyException(string className, string MethodName) 
            : base($"No se obtuvieron registros de Imagenes escaneadas. context classname{className}, methodName = {MethodName}")
        {
        }

        public ImageTrackNoContainsAnyException(string? message) : base(message)
        {
        }

        public ImageTrackNoContainsAnyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ImageTrackNoContainsAnyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
