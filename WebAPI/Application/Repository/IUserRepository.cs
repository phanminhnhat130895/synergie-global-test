using Core.Entities;

namespace Application.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckUserEmailExistingAsync(string email, CancellationToken cancellationToken);
    }
}
