using AutoMapper;
using Hostel.Extensibility.Models;
using DomainPersonal = Hostel.Domain.Models.Personal;
using ServicePersonal = Hostel.Extensibility.Models.Personal;

namespace Hostel.Domain.Mapping;

public class PersonalMappingProfile : Profile
{
    public PersonalMappingProfile()
    {
        CreateMap<DomainPersonal, SecurityPersonal>().ReverseMap();
        CreateMap<DomainPersonal, ServicePersonal>().ReverseMap();
    }
}