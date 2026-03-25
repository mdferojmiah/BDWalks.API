using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTOs
{
    public class CreateRegionDto
    {
        [Required]
        [StringLength(3, MinimumLength =3, ErrorMessage ="Region {0} must be {1} characters")]
        public string Code { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Region {0} must be between {2} to {1} characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
