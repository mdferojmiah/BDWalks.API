using BDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BDWalks.API.Data
{
    public class BDWalksDbContext : DbContext
    {
        public BDWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        // DbSet Properties
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seeding the Difficulties table with some initial data
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("f0776eec-aca2-46b0-8f62-646af060854f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("1d9b6815-e737-4140-af40-e89139e8c7d0"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("54981894-cf6c-4851-9ecb-4a6437eb643b"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // seeding the Regions table with some initial data from a JSON file
            string dataPath = "division.json";
            if (File.Exists(dataPath))
            {
                try
                {
                    var jsonRegionData = File.ReadAllText(dataPath);
                    var regions = JsonSerializer.Deserialize<List<Region>>(jsonRegionData);
                    if (regions != null)
                    {
                        modelBuilder.Entity<Region>().HasData(regions);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error while process json file:{e}");
                }
            }
            
        }
    }
}
