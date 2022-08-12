using CloudinaryDotNet.Actions;

namespace RunGroupWebApp.Interfaces
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> AddPhotoAdync(IFormFile file);
        public Task<DeletionResult> DeletePhotoAsync(string publicID);
    }
}
