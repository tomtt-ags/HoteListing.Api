using Microsoft.AspNetCore.Mvc; 
using HoteListing.Api.Model;

namespace HoteListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel{Id = 1, Name = "Grand Plaza", Address = "123 Main St", Rating = 4.5},
            new Hotel{Id = 2, Name = "Ocean View", Address = "456 Beach St", Rating = 4.8}

        }; 
        [HttpGet]   
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels); 
        }
        [HttpGet("{id}")]

        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id); 
            if(hotel == null)
            {
                return NotFound(); 
            } else
            {
                return Ok(hotel); 
            }
        }

        [HttpPost]
        public ActionResult<Hotel> Post([FromBody]Hotel newHotel)
        {
            if(hotels.Any(h => h.Id == newHotel.Id))
            {
                return BadRequest("Hotel with this Id already exists"); 
            } 
            hotels.Add(newHotel); 
            return CreatedAtAction(nameof(Get), new {id = newHotel.Id}, newHotel); 
        }
        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody]Hotel updatedHotel)
        {
            var existingHotel = hotels.FirstOrDefault(h => h.Id == id); //this will get the actual record from the list, not a copy as its pointing to a class hence it is a reference 
            if(existingHotel == null)
            {
                return NotFound("Cannot find hotel");
            }
            //exisiting hotel points to the actual class object, so we need to go to the reference and change its fields
            //individually, if we just did existingHotel = updatedHotel we just make our existingHotel point elsewhere
           existingHotel.Name = updatedHotel.Name;
           existingHotel.Address = updatedHotel.Address;
           existingHotel.Rating = updatedHotel.Rating;

           return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var delHotel = hotels.FirstOrDefault(h => h.Id == id); 
            if(delHotel == null)
            {
                return NotFound(new {message = "Message not found"}); 
            }
            hotels.Remove(delHotel); 
            return NoContent(); 
        }
    }
}