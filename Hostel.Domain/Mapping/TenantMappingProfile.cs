using AutoMapper;
using Hostel.Extensibility.Models;
using Tenant = Hostel.Domain.Models.Tenant;

namespace Hostel.Domain.Mapping;

public class TenantMappingProfile : Profile
{
    public TenantMappingProfile()
    {
        CreateMap<Tenant, SecurityTenant>().ReverseMap();
    }
}