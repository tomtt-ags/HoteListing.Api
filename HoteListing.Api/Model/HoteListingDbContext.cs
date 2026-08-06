using Microsoft.EntityFrameworkCore; 
namespace HoteListing.Api.Model
{
    public class HoteListingDbContext : DbContext
    {
        public HoteListingDbContext(DbContextOptions<HoteListingDbContext> options) : 
        base(options)
        {
            
        }

        public DbSet<Country> Countries {get; set;}
        public DbSet<Hotel> Hotels {get; set;}
        

    }
}