using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;

        public LocationController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllLocations")]
        public IActionResult GetAllLocations()
        {
            var locations = _dbContext.Locations.ToList();
            return Ok(locations);
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation(Location location)
        {
            _dbContext.Locations.Add(location);
            _dbContext.SaveChanges();
            return Ok(location);
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation(Location location)
        {
            _dbContext.Locations.Update(location);
            _dbContext.SaveChanges();
            return Ok(location);
        }

        [HttpDelete("DeleteLocation/{locationId}")]
        public IActionResult DeleteLocation(int locationId)
        {
            var location = _dbContext.Locations.Find(locationId);
            if (location != null)
            {
                _dbContext.Locations.Remove(location);
                _dbContext.SaveChanges();
                return Ok($"Location with ID {locationId} has been deleted.");
            }
            else
            {
                return NotFound($"Location with ID {locationId} not found.");
            }
        }

        [HttpGet("GetLocationById/{locationId}")]
        public IActionResult GetLocationById(int locationId)
        {
            var location = _dbContext.Locations.Find(locationId);
            if (location != null)
            {
                return Ok(location);
            }
            else
            {
                return NotFound($"Location with ID {locationId} not found.");
            }
        }

    }
}
