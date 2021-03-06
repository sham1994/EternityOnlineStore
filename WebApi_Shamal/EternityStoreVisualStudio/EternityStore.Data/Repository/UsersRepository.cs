using EternityStore.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
           var user = await _context.Users.Include(p => p.UserPhotos).FirstOrDefaultAsync(u => u.Id == id);

           return user;
        }

        public async Task<User> GetUserByUsername(string name)
        {
            string userName = name.ToLower();
            var user = await _context.Users.Include(p => p.UserPhotos).FirstOrDefaultAsync(u => u.Username == userName);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.UserPhotos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}