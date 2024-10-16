using System.Text.Json;

namespace NotificationService.exceptions
{
    public class DeserializeJsonResponseException : JsonException
    {
        public DeserializeJsonResponseException(string? details) : base($"Error al deserializar la respuesta del servidor, detalles {details}")
        {
        }
    }
}
