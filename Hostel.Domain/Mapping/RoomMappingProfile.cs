using AutoMapper;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Mapping;

public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<Room, Models.Room>().ReverseMap();
    }
}