namespace HoteListing.Api.model; 
public class Review
{
    public int Id {get; set;}

    public int Rating {get; set;}

    public string Comment {get; set;}

    public int HotelId {get; set;}

    public Hotel hotel{get; set;}
    public int UserId {get; set;}

}