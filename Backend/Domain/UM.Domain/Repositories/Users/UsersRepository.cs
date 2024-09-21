using Microsoft.EntityFrameworkCore;
using UM.Domain.Entities;
using UM.Domain.EntityFramework;

namespace UM.Domain.Repositories.Users
{
    public class UsersRepository(AppDbContext context) : IUsersRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var users = await GetAsync(id);

            if (users != null)
            {
                _context.Users.Remove(users);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetAsync(long id)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return users;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}