using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTOs;
using BDWalks.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // POST: api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalkDto createWalkDto)
        {
            // converting the walk DTO to walk domain model
            var walkDomain = mapper.Map<Walk>(createWalkDto);

            // saving the walk domain model to database
            walkDomain = await walkRepository.CreateAsync(walkDomain);

            // converting the walk domain model to walk DTO
            var walkDTO = mapper.Map<WalkDto>(walkDomain);

            // returning the walk DTO
            return Ok(walkDTO);
        }

        // GET: api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // getting the walk domain models from database
            var walksDomain = await walkRepository.GetAllAsync();

            // converting the walk domain models to walk DTOs
            var walksDTO = mapper.Map<List<WalkDto>>(walksDomain);

            // returning the list of walk DTOs
            return Ok(walksDTO);
        }

        // GET: api/walks/{id}
        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid Id)
        {
            // getting the walk domain model from database by id
            var walkDomain = await walkRepository.GetByIdAsync(Id);

            // if walk is not found then return not found response
            if (walkDomain == null)
            {
                return NotFound();
            }

            // converting the walk domain model to walk DTO
            var walkDTO = mapper.Map<WalkDto>(walkDomain);

            // returning the walk DTO
            return Ok(walkDTO);
        }

        // PUT: api/walks/{id}
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid Id, [FromBody]UpdateWalkDto updateWalkDto)
        {
            // converting the walk DTO to walk domain model
            var walkDomain = mapper.Map<Walk>(updateWalkDto);

            // updating the walk domain model in database
            walkDomain = await walkRepository.UpdateAsync(Id, walkDomain);

            // if walk is not found then return not found response
            if (walkDomain == null)
            {
                return NotFound();
            }

            // converting the walk domain model to walk DTO
            var walkDTO = mapper.Map<WalkDto>(walkDomain);

            // returning the walk DTO
            return Ok(walkDTO);
        }

        // DELETE: api/walks/{id}
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            // deleting the walk domain model from database by id
            var walkDomain = await walkRepository.DeleteAsync(Id);

            // if walk is not found then return not found response
            if (walkDomain == null)
            {
                return NotFound();
            }

            // converting the walk domain model to walk DTO
            var walkDTO = mapper.Map<WalkDto>(walkDomain);

            // returning the walk DTO
            return Ok(walkDTO);
        }
    }
}
