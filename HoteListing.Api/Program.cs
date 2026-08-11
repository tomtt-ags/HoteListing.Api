using HoteListing.Api.Model;
using HoteListing.Api.Service;
using HoteListing.Api.Contracts;
using HoteListing.Api.MappingProfiles;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//sets up the application
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HoteListingDbConnectionString");
builder.Services.AddDbContext<HoteListingDbContext>(options => options.UseSqlServer(connectionString)); 
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<HotelMappingProfile>();
    cfg.AddProfile<CountryMappingProfile>();
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
