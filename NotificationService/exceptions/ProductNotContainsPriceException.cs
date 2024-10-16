using System.Runtime.Serialization;

namespace NotificationService.exceptions
{
    public class ProductNotContainsPriceException : Exception
    {
        public ProductNotContainsPriceException()
        {
        }

        public ProductNotContainsPriceException(string details, string className, string MethodName)
            : base(new BaseExceptionInformation($"El precio del producto actual no pudo ser obtenido al escanearlo con ChatGPT, detalles {details}",
                className,
                MethodName).MessageException())
        {
        }
        public ProductNotContainsPriceException(string? message) : base(message)
        {
        }

        public ProductNotContainsPriceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductNotContainsPriceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
