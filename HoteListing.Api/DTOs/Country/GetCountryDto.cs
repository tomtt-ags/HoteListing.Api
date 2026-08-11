using HoteListing.Api.DTOs.Hotel;
namespace HoteListing.Api.DTOs.Country;
public class GetCountryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<GetHotelsDto> Hotels { get; set; } = new();
}
