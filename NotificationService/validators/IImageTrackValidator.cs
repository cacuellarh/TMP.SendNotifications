using NotificationService.data.Models;

namespace NotificationService.validators
{
    public interface IImageTrackValidator
    {
        public void ValidateImageTracksContainsAny(IReadOnlyCollection<ImageTrack> records, string className, string methodName);
        
    }
}
