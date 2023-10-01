namespace Domain.Interfaces;


public interface IUnitOfWork
{
    public IPerson Persons { get; }

    Task<int> SaveAsync();
}