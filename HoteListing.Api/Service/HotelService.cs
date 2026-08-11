using HoteListing.Api.DTOs.Hotel;
using HoteListing.Api.Model;
using Microsoft.EntityFrameworkCore;
using HoteListing.Api.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HoteListing.Api.Results;
using System.Linq.Expressions;

namespace HoteListing.Api.Service;
public class HotelService(HoteListingDbContext context, IMapper mapper, ICountryService countryService) : IHotelService
{
    public async Task<Result<IEnumerable<GetHotelsDto>>> GetAllAsync()
    {
        var hotels = await context.Hotels
        .ProjectTo<GetHotelsDto>(mapper.ConfigurationProvider)
        .ToListAsync();
        return Result<IEnumerable<GetHotelsDto>>.Success(hotels);
    }

    public async Task<Result<GetHotelDto>> GetAsync(int id)
    {
        var hotel = await context.Hotels
        .Where(h => h.Id == id)
        .ProjectTo<GetHotelDto>(mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();
        return hotel is null ? Result<GetHotelDto>.Failure(new Error(ErrorCodes.NotFound, $"Hotel '{id}' was not found.")) : Result<GetHotelDto>.Success(hotel);
    }
     public async Task<Result> UpdateHotelAsync(int id, UpdateHotelDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return Result.BadRequest(new Error(ErrorCodes.Validation, "Id route value does not match payload Id."));
        }

        var hotel = await context.Hotels.FindAsync(id);
        if (hotel is null)
        {
            return Result.NotFound(new Error(ErrorCodes.NotFound, $"Hotel '{id}' was not found."));
        }

        var countryExists = await countryService.CountryExistsAsync(updateDto.CountryId);
        if (!countryExists)
        {
            return Result.NotFound(new Error(ErrorCodes.NotFound, $"Country '{updateDto.CountryId}' was not found."));
        }

        mapper.Map(updateDto, hotel);

        context.Hotels.Update(hotel);
        await context.SaveChangesAsync();

        return Result.Success();
    }
    public async Task<Result<GetHotelDto>> CreateHotelAsync(CreateHotelDto hotelDto)
    {
        var countryExists = await countryService.CountryExistsAsync(hotelDto.CountryId);
        if (!countryExists)
        {
            return Result<GetHotelDto>.Failure(new Error(ErrorCodes.NotFound, $"Country '{hotelDto.CountryId}' was not found."));
        }

        var duplicate = await HotelExistsAsync(hotelDto.Name, hotelDto.CountryId);
        if (duplicate)
        {
            return Result<GetHotelDto>.Failure(new Error(ErrorCodes.Conflict, $"Hotel '{hotelDto.Name}' already exists in the selected country."));
        }

        var hotel = mapper.Map<Hotel>(hotelDto);
        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();

        var dto = await context.Hotels
            .Where(h => h.Id == hotel.Id)
            .ProjectTo<GetHotelDto>(mapper.ConfigurationProvider)
            .FirstAsync();

        return Result<GetHotelDto>.Success(dto);
    }

     public async Task<Result> DeleteHotelAsync(int id)
    {
        var affected = await context.Hotels
            .Where(q => q.Id == id)
            .ExecuteDeleteAsync();

        if (affected == 0)
        {
            return Result.NotFound(new Error(ErrorCodes.NotFound, $"Hotel '{id}' was not found."));
        }

        return Result.Success();
    }

    public async Task<bool> HotelExistsAsync(int id)
    {
        return await context.Hotels.AnyAsync(e => e.Id == id);
    }
    public async Task<bool> HotelExistsAsync(string name, int countryId)
    {
        return await context.Hotels
            .AnyAsync(e => e.Name.ToLower().Trim() == name.ToLower().Trim() && e.CountryId == countryId);
    }
}