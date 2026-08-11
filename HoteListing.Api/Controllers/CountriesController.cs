using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoteListing.Api.Model;
using HoteListing.Api.Contracts;
using HoteListing.Api.DTOs.Country;
using HoteListing.Api.DTOs.Hotel;


namespace HoteListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController(ICountryService countryService) : BaseApiController
{
    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountriesDto>>> GetCountries()
    {
        var countries = await countryService.GetAllAsync();
        return ToActionResult(countries);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
    {
        var country = await countryService.GetAsync(id);
        return ToActionResult(country);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(int id, UpdateCountryDto countryDto)
    {
        var result = await countryService.UpdateCountryAsync(id, countryDto);
        return ToActionResult(result);
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<GetCountryDto>> PostCountry(CreateCountryDto countryDto)
    {
        var result = await countryService.CreateAsync(countryDto);
        if (!result.IsSuccess) return MapErrorsToResponse(result.Errors);

        return CreatedAtAction(nameof(GetCountry), new { id = result.Value!.Id }, result.Value);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var result = await countryService.DeleteAsync(id);
        return ToActionResult(result);
    }
}

