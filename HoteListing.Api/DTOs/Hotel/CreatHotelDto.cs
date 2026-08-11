using System.ComponentModel.DataAnnotations;
namespace HoteListing.Api.DTOs.Hotel;
public class CreateHotelDto
{
    public required string Name {get; set;}
    [MaxLength(100)]
    public required string Address {get; set;}
    public double Rating {get; set;}
    public int CountryId {get; set;}
}