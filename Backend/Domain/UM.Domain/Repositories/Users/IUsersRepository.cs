using UM.Domain.Entities;

namespace UM.Domain.Repositories.Users
{
    public interface IUsersRepository
    {
        Task CreateAsync(User entity);
        Task<User?> GetAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User entity);
        Task DeleteAsync(long id);
    }

}