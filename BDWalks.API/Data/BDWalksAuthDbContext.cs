using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Data
{
    public class BDWalksAuthDbContext : IdentityDbContext
    {
        public BDWalksAuthDbContext(DbContextOptions<BDWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerUserId = "b433a2b8-bd22-497e-846e-ea60762c3e05";
            var writerUserId = "a045e9d2-5dcc-4661-8531-4cd2076c1fb2";

            var role = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerUserId,
                    ConcurrencyStamp = readerUserId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerUserId,
                    ConcurrencyStamp = writerUserId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(role);
        }
    }
}
