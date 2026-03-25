using AutoMapper;
using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTOs;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GET: api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // getting the region domain models from database
            var regionsDomain = await regionRepository.GetAllAsync();

            //converting the region domain to region DTO
            var regionsDTO = mapper.Map<List<RegionDto>>(regionsDomain);

            //returning the list of regions DTO
            return Ok(regionsDTO);
        }


        // GET: api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // getting the region domain model from database by id
            var regionDomain = await regionRepository.GetByIdAsync(id);

            // if region is not found then return not found response
            if (regionDomain == null)
            {
                return NotFound();
            }

            // converting the region domain to region DTO
            var regionDTO = mapper.Map<RegionDto>(regionDomain);

            // returning the region DTO
            return Ok(regionDTO);
        }


        // POST: api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto createRegionDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            // converting the region DTO to region domain model
            var regionDomain = mapper.Map<Region>(createRegionDto);

            // saving the region domain model to database
            regionDomain = await regionRepository.CreateAsync(regionDomain);

            // converting the region domain to region DTO
            var regionDTO = mapper.Map<RegionDto>(regionDomain);

            // returning the created response with the region DTO
            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
        }


        // PUT: api/regions/{id}
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            // converting the region DTO to region domain model
            var region = mapper.Map<Region>(updateRegionDto);

            // updating the region domain model in database by id
            var regionDomain = await regionRepository.UpdateAsync(Id, region);

            // if region is not found then return not found response
            if (regionDomain == null)
            {
                return NotFound();
            }

            // converting the region domain to region DTO 
            var regionDTO = mapper.Map<RegionDto>(regionDomain);

            // returning the updated region DTO
            return Ok(regionDTO);
        }


        // DELETE: api/regions/{id}
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            // deleting the region domain model from database by id
            var regionDomain = await regionRepository.DeleteAsync(Id);

            // if region is not found then return not found response
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDTO);
        }
    }
}
