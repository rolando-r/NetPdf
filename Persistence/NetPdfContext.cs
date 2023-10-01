using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class NetPdfContext : DbContext
{
    public NetPdfContext(DbContextOptions<NetPdfContext> options) : base(options)
    {
    }
    public DbSet<Person> Persons {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
}