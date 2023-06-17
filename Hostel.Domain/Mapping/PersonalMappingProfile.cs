using AutoMapper;
using Hostel.Extensibility.Models;
using Personal = Hostel.Domain.Models.Personal;

namespace Hostel.Domain.Mapping;

public class PersonalMappingProfile : Profile
{
    public PersonalMappingProfile()
    {
        CreateMap<Personal, SecurityPersonal>().ReverseMap();
    }
}