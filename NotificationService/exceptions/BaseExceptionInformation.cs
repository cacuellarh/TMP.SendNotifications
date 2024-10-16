namespace NotificationService.exceptions
{
    public class BaseExceptionInformation
    {
        public BaseExceptionInformation(string details, string className, string methodName)
        {
            Details = details;
            ClassName = className;
            MethodName = methodName;
        }

        public string Details { get; private set; }
        public string ClassName { get; private set; }
        public string MethodName { get; private set; }

        public string MessageException()
        {
            return 
            $"Ocurrio un error al realizar una operacion en la clase ('{ClassName}')" +
            $"Nombre del metodo ('{MethodName}'), \n" +
            $" detalles del error: {Details}";
        }

    }
}
