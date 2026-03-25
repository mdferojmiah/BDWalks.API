using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTOs
{
    public class UpdateRegionDto
    {
        [StringLength(3, ErrorMessage = "Region {0} must be {1} characters")]
        public string Code { get; set; }
        [StringLength(100, ErrorMessage = "Region {0} must be less than {1} characters")]
        public string Name { get; set; }
        public string? RegionImageUrll { get; set; }
    }
}
