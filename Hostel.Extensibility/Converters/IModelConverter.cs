namespace Hostel.Extensibility.Converters;

public interface IModelConverter<TServiceModel, TDomainModel>
{
    TServiceModel ToServiceModel(TDomainModel domainModel);

    TServiceModel ToServiceModel(TDomainModel domainModel, TServiceModel serviceModel);

    TDomainModel ToDomainModel(TServiceModel serviceModel);

    TDomainModel ToDomainModel(TServiceModel serviceModel, TDomainModel domainModel);
}