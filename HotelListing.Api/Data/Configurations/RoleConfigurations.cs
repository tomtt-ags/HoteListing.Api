using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Api.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "c78e8f15-6a6c-4c8a-b5d1-98394b071953",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "b1a2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"
            },
            new IdentityRole
            {
                Id = "36aac992-72ff-4527-9008-52e7c145ca39",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "d2b3c4d5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"
            },
            new IdentityRole
            {
                Id = "36aac992-4c8a-4527-9008-98394b071953",
                Name = "Hotel Admin",
                NormalizedName = "HOTEL ADMIN",
                ConcurrencyStamp = "e3c4d5e6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"
            }
        );
    }
}
