namespace Application.Repository
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
