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

        public async Task<List<Walk>> GetAllAsync()
        {
            var result = await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();
            return result;
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

            existingWalk.Name = string.IsNullOrEmpty(walk.Name) ? existingWalk.Name : walk.Name;
            existingWalk.LengthInKm = walk.LengthInKm == 0 ? existingWalk.LengthInKm : walk.LengthInKm;
            existingWalk.Description = string.IsNullOrEmpty(walk.Description) ? existingWalk.Description : walk.Description;
            existingWalk.WalkImageUrl = string.IsNullOrEmpty(walk.WalkImageUrl) ? existingWalk.WalkImageUrl : walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId == Guid.Empty ? existingWalk.RegionId : walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId == Guid.Empty ? existingWalk.DifficultyId : walk.DifficultyId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
