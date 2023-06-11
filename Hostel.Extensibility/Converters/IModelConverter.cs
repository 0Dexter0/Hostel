namespace Hostel.Extensibility.Converters;

public interface IModelConverter<TServiceModel, TDomainModel>
{
    TServiceModel ToServiceModel(TDomainModel domainModel);

    TDomainModel ToDomainModel(TServiceModel serviceModel);
}