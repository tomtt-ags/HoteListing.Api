using HoteListing.Api.DTOs.Hotel;
namespace HoteListing.Api.DTOs.Country;
public record GetCountriesDto{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    }