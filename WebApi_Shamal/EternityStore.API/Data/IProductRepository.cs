using System.Collections.Generic;
using System.Threading.Tasks;
using EternityStore.API.Models;

namespace EternityStore.API.Data
{
    public interface IProductRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();
        // a= there is somehting to get saved to database / b = there is an error to get saved to database
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);
    }
}