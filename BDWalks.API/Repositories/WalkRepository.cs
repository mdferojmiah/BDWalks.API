using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly BDWalksDbContext dbContext;

        public WalkRepository(BDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid Id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if(existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? queryOn = null, string? queryBy = null, string? orderBy = null, bool isAscending = true)
        {
            // getting queryable Walks inculding the related Difficulty and Region data
            var result = dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            // filtering
            if (string.IsNullOrWhiteSpace(queryOn) == false && string.IsNullOrWhiteSpace(queryBy) == false)
            {
                if(queryOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.Where(x => x.Name.Contains(queryBy));
                }
            }

            // sorting
            if(string.IsNullOrWhiteSpace(orderBy) == false)
            {
                if(orderBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    result = isAscending ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name);
                }
            }

            // executing and returning the list of walks
            return await result.ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid Id)
        {
            var result = await dbContext.Walks.Include(x => x.Difficulty)
                                        .Include(x => x.Region)
                                        .FirstOrDefaultAsync(x => x.Id == Id);
            if(result == null)
            {
                return null;
            }

            return result;

        }

        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name.Length < 3 ? existingWalk.Name : walk.Name;
            existingWalk.LengthInKm = walk.LengthInKm <= 0 ? existingWalk.LengthInKm : walk.LengthInKm;
            existingWalk.Description = walk.Description.Length < 5 ? existingWalk.Description : walk.Description;
            existingWalk.WalkImageUrl = string.IsNullOrEmpty(walk.WalkImageUrl) ? existingWalk.WalkImageUrl : walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId == Guid.Empty  ? existingWalk.RegionId : walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId == Guid.Empty ? existingWalk.DifficultyId : walk.DifficultyId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
