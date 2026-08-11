namespace HoteListing.Api.DTOs.Hotel;
public class GetHotelDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string CountryName { get; set; } = string.Empty;
}