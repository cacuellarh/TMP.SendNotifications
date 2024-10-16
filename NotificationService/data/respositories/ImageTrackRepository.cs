using NotificationService.data.Models;

namespace NotificationService.data.respositories
{
    public class ImageTrackRepository : BaseRepository<ImageTrack>, IImageTrackRepository
    {
        public ImageTrackRepository(TmpContext tmpContext) : base(tmpContext)
        {
        }
    }
}
