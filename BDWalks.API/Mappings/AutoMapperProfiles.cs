using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTOs;

namespace BDWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // mapping for Region
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<CreateRegionDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
            // mapping for Walk
            CreateMap<CreateWalkDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            // mapping for Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();
        }
    }
}
