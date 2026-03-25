using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTOs
{
    public class CreateWalkDto
    {
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Walk {0} must be between {2} to {1} characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Walk {0} must be between {2} to {1} characters")]
        public string Description { get; set; }
        [Required]
        [Range(0.1, 50, ErrorMessage ="Walk Length must be between {1} to {2} KM")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
    }
}
