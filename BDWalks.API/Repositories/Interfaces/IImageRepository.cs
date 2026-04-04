using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
