using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoteListing.Api.Model;
using HoteListing.Api.DTOs.Hotel;
using HoteListing.Api.Contracts;

namespace HoteListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(IHotelService hotelService) : BaseApiController
{
    
    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHotelsDto>>> GetHotels()
    {
        var hotels = await hotelService.GetAllAsync();
        return ToActionResult(hotels);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetHotelDto>> GetHotel(int id)
    {
        var hotel = await hotelService.GetAsync(id);
        return ToActionResult(hotel);
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, UpdateHotelDto hotelDto)
    {
        if (id != hotelDto.Id)
        {
            return BadRequest();
        }
        var hotel = await hotelService.UpdateHotelAsync(id, hotelDto);
        return ToActionResult(hotel);
    }

    // POST: api/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto hotelDto)
    {
        var hotel = await hotelService.CreateHotelAsync(hotelDto);
        if (!hotel.IsSuccess) return MapErrorsToResponse(hotel.Errors);

        return CreatedAtAction("GetHotel", new { id = hotel.Value!.Id }, hotel.Value);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await hotelService.DeleteHotelAsync(id);
        return ToActionResult(hotel);
    }
}

