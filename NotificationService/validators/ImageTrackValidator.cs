using NanisGuard.src;
using NotificationService.data.Models;
using NotificationService.exceptions;

namespace NotificationService.validators
{
    public class ImageTrackValidator : IImageTrackValidator
    {
        public void ValidateImageTracksContainsAny(IReadOnlyCollection<ImageTrack> records, string className, string methodName)
        {
            {
                NanisGuardV.validation.EnumerableNotEmpty(records,
                    customException: () => {
                        return new ImageTrackNoContainsAnyException(className, methodName);
                    });
            }
        }
    }
}
