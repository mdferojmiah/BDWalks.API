using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTOs
{
    public class UpdateWalkDto
    {
        [StringLength(100, ErrorMessage = "Walk {0} must be between less than {1} characters")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Walk {0} must be between less than {1} characters")]
        public string Description { get; set; }
        [Range(0.1, 50, ErrorMessage = "Walk Length must be between {1} to {2} KM")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}
