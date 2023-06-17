using AutoMapper;
using Hostel.Extensibility.Converters;

namespace Hostel.Service.Converters;

public class ModelConverter<TServiceModel, TDomainModel> : IModelConverter<TServiceModel, TDomainModel>
{
    private readonly IMapper _mapper;

    public ModelConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TServiceModel ToServiceModel(TDomainModel domainModel) => _mapper.Map<TServiceModel>(domainModel);

    public TServiceModel ToServiceModel(TDomainModel domainModel, TServiceModel serviceModel) =>
        _mapper.Map(domainModel, serviceModel);

    public TDomainModel ToDomainModel(TServiceModel serviceModel) => _mapper.Map<TDomainModel>(serviceModel);

    public TDomainModel ToDomainModel(TServiceModel serviceModel, TDomainModel domainModel) =>
        _mapper.Map(serviceModel, domainModel);
}