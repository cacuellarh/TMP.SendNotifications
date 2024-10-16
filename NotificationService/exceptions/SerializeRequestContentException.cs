using System.Text.Json;

namespace NotificationService.exceptions
{
    public class SerializeRequestContentException : JsonException
    {
        public SerializeRequestContentException(string? nameRequest, string details) 
            : base($"Error al serializar la peticion {nameRequest}, detalles : {details}")
        {
        }
    }
}
