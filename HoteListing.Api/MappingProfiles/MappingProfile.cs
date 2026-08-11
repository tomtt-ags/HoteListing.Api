using AutoMapper;
using HoteListing.Api.DTOs.Country;
using HoteListing.Api.DTOs.Hotel;
using HoteListing.Api.Model;
namespace HoteListing.Api.MappingProfiles;
public class HotelMappingProfile : Profile
{
    public HotelMappingProfile()
    {
        CreateMap<Hotel, GetHotelDto>()
            .ForMember(dest => dest.CountryName, cfg => cfg.MapFrom<CountryNameResolver>());
        CreateMap<Hotel, GetHotelsDto>();
        CreateMap<CreateHotelDto, Hotel>();
    }
}
public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<Country, GetCountryDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CountryId));;
        CreateMap<Country, GetCountriesDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CountryId));;
        CreateMap<CreateCountryDto, Country>();
    }
}
public class CountryNameResolver : IValueResolver<Hotel, GetHotelDto, string>
{
    
    public string Resolve(Hotel source, GetHotelDto destination, string destMember, ResolutionContext context)
    {
        return source.country?.Name ?? string.Empty;
    }
}