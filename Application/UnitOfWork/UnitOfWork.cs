using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    PersonRepository _person;
   

    private readonly NetPdfContext _context;
    public UnitOfWork(NetPdfContext context)
    {
        _context = context;
    }
    public IPersonRepository Persons
    {
        get
        {
            _person ??= new PersonRepository(_context);
            return _person;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
