using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTOs;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        // POST: api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] AddImageRequestDto addImageRequestDto)
        {
            ValidateFileUpload(addImageRequestDto);

            if(ModelState.IsValid)
            {
                // convert the Dto to domain
                var imageDomain = new Image
                {
                    File = addImageRequestDto.File,
                    FileName = addImageRequestDto.FileName,
                    FileDescription = addImageRequestDto.FileDescription,
                    FileSize = addImageRequestDto.File.Length,
                    FileExtension = Path.GetExtension(addImageRequestDto.File.FileName)
                };

                // upload image using image repository
                await imageRepository.Upload(imageDomain);
                return Ok(imageDomain);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(AddImageRequestDto addImageRequestDto)
        {
            var allowedExtensions = new string[] {".jpeg", ".png", ".jpg"};

            if (!allowedExtensions.Contains(Path.GetExtension(addImageRequestDto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported File Upload!");
            }

            if(addImageRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("size", "File size is too long!");
            }
        }
    }
}
