using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Domain.Repositories;

internal class AuthPersonalRepository : IAuthPersonalRepository
{
    private readonly HostelDbContext _context;
    private readonly IModelConverter<Personal, Models.Personal> _modelConverter;

    public AuthPersonalRepository(HostelDbContext context, IModelConverter<Personal, Models.Personal> modelConverter)
    {
        _context = context;
        _modelConverter = modelConverter;
    }

    public Personal GetByPhoneNumber(string phoneNumber)
    {
        var personal = _context.Personals.AsQueryable().FirstOrDefault(x => x.PhoneNumber == phoneNumber);

        return personal is null ? null : _modelConverter.ToServiceModel(personal);
    }

    public bool Add(Personal model)
    {
        var resultState = _context.Personals.Add(_modelConverter.ToDomainModel(model)).State;
        _context.SaveChanges();

        return resultState is EntityState.Added;
    }
}