using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? queryOn = null, string? queryBy = null, string? ordreBy = null, bool isAscending = true);
        Task<Walk?> GetByIdAsync(Guid Id);
        Task<Walk?> UpdateAsync(Guid Id, Walk walk);
        Task<Walk?> DeleteAsync(Guid Id);
    }
}
