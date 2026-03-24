
using BDWalks.API.Data;
using BDWalks.API.Mappings;
using BDWalks.API.Repositories;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BDWalks.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // DbContext Configuration
            builder.Services.AddDbContext<BDWalksDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("BDWalksConnectionString"))
            );

            // injecting the repositories
            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<IWalkRepository, WalkRepository>();

            // injecting automapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
