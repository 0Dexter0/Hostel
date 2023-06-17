using AutoMapper;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Mapping;

public class DocumentMappingProfile : Profile
{
    public DocumentMappingProfile()
    {
        CreateMap<Document, Models.Document>().ReverseMap();
    }
}