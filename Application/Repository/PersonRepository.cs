using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PersonRepository : GenericRepository<Person>, IPerson
{
    private readonly NetPdfContext _context;
    public PersonRepository(NetPdfContext context) : base(context)
    { 
        _context = context; 
    }

    public override async Task<(int totalRegistros,IEnumerable<Person> registros)> GetAllAsync(int pageIndex,int pageSize,string search)
     {
        var query = _context.Persons as IQueryable<Person>;
        if(!string.IsNullOrEmpty(search))
        {
            query  = query.Where(p => p.Name.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return ( totalRegistros, registros);
     }
}
