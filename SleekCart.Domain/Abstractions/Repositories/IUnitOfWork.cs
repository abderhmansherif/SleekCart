namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
