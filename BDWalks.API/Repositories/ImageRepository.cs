using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Repositories.Interfaces;

namespace BDWalks.API.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BDWalksDbContext dbContext;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, BDWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
         
        public async Task<Image> Upload(Image image)
        {
            // getting the local file path
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            //  createing FileStream and save the photo into the local file
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // creating url path for 
            // https://localhost:7296/Images/filename.extension
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            // adding this urlFilePath to image path
            image.FilePath = urlFilePath;

            // saving the image domain to database
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            // returning the image
            return image;
        }
    }
}
