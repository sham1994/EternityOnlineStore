using System.Collections.Generic;
using System.Threading.Tasks;
using EternityStore.Data.Model;

namespace EternityStore.Data.Repository
{
    public interface IUsersRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();
        // a= there is somehting to get saved to database / b = there is an error to get saved to database
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task<User> GetUserByUsername(string name);



    }
}