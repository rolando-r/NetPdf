using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected  readonly NetPdfContext _context;
    public GenericRepository(NetPdfContext context)
    {
        _context = context;
    }

    public virtual void Add(T Entity)
    {
        _context.Set<T>().Add(Entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).ToList();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

   public async virtual Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int Id)
    {
        return await _context.Set<T>().FindAsync(Id);
    }

    public virtual void Remove(T Entity)
    {
        _context.Set<T>().Remove(Entity);
    }

    public virtual void RemoveRange(T entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Update(T Entity)
    {
        _context.Set<T>().Update(Entity);
    } 

}
