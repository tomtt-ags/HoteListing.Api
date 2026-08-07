namespace HoteListing.Api.Model; 
public class Country
{
    public int CountryId {get; set;}
    
    public string Name {get; set;}

    public string Shortname {get; set;}

    public double Rating{get; set;}

    public IList<Hotel> hotels {get; set;}
    //Console.WriteLine("hey"); 

}