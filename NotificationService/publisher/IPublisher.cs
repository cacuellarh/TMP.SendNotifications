namespace NotificationService.publisher
{
    public interface IPublisher<T>
    {
        public void Publish(T e);
    }
}
