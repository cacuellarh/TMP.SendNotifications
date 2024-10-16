using NotificationService.data.Models;

namespace NotificationService.interfaces
{
    public interface IImageTrackService
    {
        public Task<IReadOnlyList<ImageTrack>> GetImageTracksAsync();
    }
}
