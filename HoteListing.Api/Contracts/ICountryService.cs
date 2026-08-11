using HoteListing.Api.DTOs.Country;
using HoteListing.Api.Results;
namespace HoteListing.Api.Contracts;
public interface ICountryService
{
    Task<Result<IEnumerable<GetCountriesDto>>> GetAllAsync();
    Task<Result<GetCountryDto>> GetAsync(int id);

    Task<Result> UpdateCountryAsync(int id, UpdateCountryDto countryDto);
    Task<Result<GetCountryDto>> CreateAsync(CreateCountryDto countryDto);
    Task<Result> DeleteAsync(int id);
    Task<bool> CountryExistsAsync(int id);
    Task<bool> CountryExistsAsync(string name);
}