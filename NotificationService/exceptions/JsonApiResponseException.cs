using System.Runtime.Serialization;

namespace NotificationService.exceptions
{
    public class JsonApiResponseException : Exception
    {
        public JsonApiResponseException(string details) 
            : base($"La respuesta contenida en JsonApiResponse o el value contenido es null, detalles {details}")
        {
        }

        public JsonApiResponseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected JsonApiResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
