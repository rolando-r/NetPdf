using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    private readonly NetPdfContext _context;
    public PersonRepository(NetPdfContext context) : base(context)
    { 
        _context = context; 
    }
}
