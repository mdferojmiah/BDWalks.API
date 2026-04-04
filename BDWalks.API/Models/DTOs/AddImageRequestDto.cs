using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTOs
{
    public class AddImageRequestDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
