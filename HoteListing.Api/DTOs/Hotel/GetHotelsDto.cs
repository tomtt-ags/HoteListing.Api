namespace HoteListing.Api.DTOs.Hotel;
public class GetHotelsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Rating { get; set; }
}