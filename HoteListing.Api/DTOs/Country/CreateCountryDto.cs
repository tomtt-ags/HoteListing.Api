using System.ComponentModel.DataAnnotations;
namespace HoteListing.Api.DTOs.Country;
public class CreateCountryDto
{
    [Required]
    [MaxLength(100)]
    public required string Name {get; set;}
    [Required]
    [MaxLength(10)]
    public required string Shortname {get; set;}
}