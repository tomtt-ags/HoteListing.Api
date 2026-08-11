namespace HoteListing.Api.Model; 
public class Country
{
    public int CountryId {get; set;}
    public required string Name {get; set;}
    public required string Shortname {get; set;}

    public IList<Hotel> hotels {get; set;} = new List<Hotel>();


}