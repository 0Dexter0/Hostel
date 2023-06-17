using AutoMapper;

namespace Hostel.Domain.Mapping;

public class HostelMappingProfile : Profile
{
    public HostelMappingProfile()
    {
        CreateMap<Models.Hostel, Extensibility.Models.Hostel>();
        CreateMap<Extensibility.Models.Hostel, Models.Hostel>();
    }
}