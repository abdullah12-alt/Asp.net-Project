using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Model.Domain;
using NZWalk.API.Model.DTO;

namespace NZWalk.API.Controllers
{
    [Route("api/Regions")]

    [ApiController]
    public class RegionsController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = "Ack",
        //            Name = "Ackland",
        //            ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/04/18/97/d4/ackland.jpg"
        //        }
        //    };

        //    return Ok(regions);
        //}
        private readonly NZWalkDbContext dbContext;

        public RegionsController(NZWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = dbContext.Regions.ToList();
        //    return Ok(regions);
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions
                .Select(r => new RegionDTO
                {
                    Id = r.Id,
                    Code = r.Code,
                    Name = r.Name,
                    ImageUrl = r.ImageUrl
                })
                .ToList();

            return Ok(regions);
        }



        // Get a region by Id
        //[HttpGet("{id}")]
        //public  IActionResult GetById(Guid id)
        //{
        //    var region = dbContext.Regions
        //        .Where(r => r.Id == id)
        //        .Select(r => new RegionDTO
        //        {
        //            Id = r.Id,
        //            Code = r.Code,
        //            Name = r.Name,
        //            ImageUrl = r.ImageUrl
        //        })
        //        .FirstOrDefault();

        //    if (region == null)
        //    {
        //        return NotFound("Region not found.");
        //    }

        //    return Ok(region);
        //}

        // Get a region by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await dbContext.Regions
                .Where(r => r.Id == id)
                .Select(r => new RegionDTO
                {
                    Id = r.Id,
                    Code = r.Code,
                    Name = r.Name,
                    ImageUrl = r.ImageUrl
                })
                .FirstOrDefaultAsync();

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            return Ok(region);
        }

        // Add a new region (POST)
        //[HttpPost]
        //public IActionResult Create([FromBody] CreateRegionDTO newRegionDto)
        //{
        //    if (newRegionDto == null)
        //    {
        //        return BadRequest("Invalid region data.");
        //    }

        //    var newRegion = new Region
        //    {
        //        Code = newRegionDto.Code,
        //        Name = newRegionDto.Name,
        //        ImageUrl = newRegionDto.ImageUrl
        //    };

        //    dbContext.Regions.Add(newRegion);
        //    dbContext.SaveChanges();

        //    var createdRegionDto = new RegionDTO
        //    {
        //        Id = newRegion.Id,
        //        Code = newRegion.Code,
        //        Name = newRegion.Name,
        //        ImageUrl = newRegion.ImageUrl
        //    };

        //    return CreatedAtAction(nameof(GetById), new { id = createdRegionDto.Id }, createdRegionDto);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDTO newRegionDto)
        {
            if (newRegionDto == null)
            {
                return BadRequest("Invalid region data.");
            }

            var newRegion = new Region
            {
                Code = newRegionDto.Code,
                Name = newRegionDto.Name,
                ImageUrl = newRegionDto.ImageUrl
            };

           await dbContext.Regions.AddAsync(newRegion);
          await  dbContext.SaveChangesAsync();

            var createdRegionDto = new RegionDTO
            {
                Id = newRegion.Id,
                Code = newRegion.Code,
                Name = newRegion.Name,
                ImageUrl = newRegion.ImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = createdRegionDto.Id }, createdRegionDto);
        }
        // Delete a region by Id (DELETE)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
            {
                return NotFound("Region not found.");
            }

            dbContext.Regions.Remove(region);
            dbContext.SaveChanges();

            return NoContent(); // Successful deletion with no content in response
        }
    }


}
