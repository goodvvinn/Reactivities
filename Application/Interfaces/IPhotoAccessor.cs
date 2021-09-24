namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using Application.Photos;
    using Microsoft.AspNetCore.Http;

    public interface IPhotoAccessor
    {
        Task<PhotoUploadResults> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
