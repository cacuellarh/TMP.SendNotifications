using NotificationService.data.Models;
using NotificationService.data.respositories;
using NotificationService.interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using NotificationService.exceptions;
using NotificationService.validators;

namespace NotificationService.services
{
    public class ImageTrackService : IImageTrackService
    {
        private readonly IImageTrackRepository _repository;
        private readonly IImageTrackValidator _imageTrackValidator;
        public ImageTrackService(IImageTrackRepository repository,
            IImageTrackValidator imageTrackValidator
            )
        {
            _repository = repository;
            _imageTrackValidator = imageTrackValidator;
        }

        public async Task<IReadOnlyList<ImageTrack>> GetImageTracksAsync()
        {
            try
            {
                var entities = await _repository.GetAllAsync<ImageTrack>(
                    imageTrack => imageTrack.Include(i => i.Product),
                    imageTrack => imageTrack.CanScan == true);

                var imageTracks = entities.OfType<ImageTrack>().ToList().AsReadOnly();

                _imageTrackValidator.ValidateImageTracksContainsAny(imageTracks, nameof(ImageTrackService),nameof(GetImageTracksAsync));

                return imageTracks.AsReadOnly();
            }
            catch (Exception ex) 
            {
                var exception = new RepositoryException(
                    new BaseExceptionInformation(ex.Message, nameof(ImageTrackService), nameof(GetImageTracksAsync))
                );

                Log.Error(exception, "Error al obtener los tracks de imágenes desde el repositorio.");
                throw;
            }
            
        }
    }
}
