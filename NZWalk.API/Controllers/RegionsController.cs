using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Data;
using NZWalk.API.Model.Domain;

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

        public NZWalkDbContext DbContext { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }
    }
}
