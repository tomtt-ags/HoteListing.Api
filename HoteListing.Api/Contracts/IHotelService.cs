using HoteListing.Api.DTOs.Hotel;
using HoteListing.Api.Results;
namespace HoteListing.Api.Contracts;
public interface IHotelService
{
    Task<Result<IEnumerable<GetHotelsDto>>> GetAllAsync();
    Task<Result<GetHotelDto>> GetAsync(int id);
    Task<Result> UpdateHotelAsync(int id, UpdateHotelDto hotelDto);
    Task<Result<GetHotelDto>> CreateHotelAsync(CreateHotelDto hotelDto);
    Task<Result> DeleteHotelAsync(int id);

    Task<bool> HotelExistsAsync(int id);
    Task<bool> HotelExistsAsync(string name, int countryId);
}