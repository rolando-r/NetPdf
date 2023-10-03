namespace Domain.Interfaces;


public interface IUnitOfWork
{
    public IPersonRepository Persons { get; }

    Task<int> SaveAsync();
}