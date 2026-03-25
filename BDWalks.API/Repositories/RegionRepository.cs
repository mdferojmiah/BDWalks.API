using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly BDWalksDbContext dbContext;
        public RegionRepository(BDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if(region == null)
            {
                return null;
            }   

            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var regionToUpdate = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(regionToUpdate == null)
            {
                return null;
            }

            regionToUpdate.Code = region.Code.Length < 3 ? regionToUpdate.Code : region.Code;
            regionToUpdate.Name = region.Name.Length < 3 ? regionToUpdate.Name : region.Name;
            regionToUpdate.RegionImageUrl = string.IsNullOrEmpty(region.RegionImageUrl) ? regionToUpdate.RegionImageUrl : region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return regionToUpdate;
        }
    }
}
