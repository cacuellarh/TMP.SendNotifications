using System.Reflection;

namespace NotificationService.exceptions
{
    public class RepositoryException : Exception
    {
        public string MessageError { get; private set; }
        public RepositoryException(BaseExceptionInformation informationErr) : 
            base(informationErr.MessageException())
        {
        }
    }
}
