using AutoMapper;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Mapping;

public class VisitMappingProfile : Profile
{
    public VisitMappingProfile()
    {
        CreateMap<Visit, Models.Visit>().ReverseMap();
    }
}