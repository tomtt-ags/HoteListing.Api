using HoteListing.Api.Model;

namespace HoteListing.Api.Model; 
public class Hotel
{
    public int Id {get; set;}
    
    public required string Name {get; set;}

    public required string Address {get; set;}

    public double Rating{get; set;}

    public int CountryId{get; set;}
    
    public Country? country{get; set;}


}