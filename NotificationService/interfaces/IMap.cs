namespace NotificationService.interfaces
{
    public interface IMap<Tin,Tout>
    {
        public Tout Map(Tin input);
    }
}
