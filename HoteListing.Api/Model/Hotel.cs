using HoteListing.Api.model;

namespace HoteListing.Api.Model; 
public class Hotel
{
    public int Id {get; set;}
    
    public string Name {get; set;}

    public string Address {get; set;}

    public double Rating{get; set;}

    public int CountryId{get; set;}
    
    public Country? country{get; set;}

    public IList<Review> reviews{get; set;}

}