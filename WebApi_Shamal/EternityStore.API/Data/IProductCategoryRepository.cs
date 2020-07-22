using System.Collections.Generic;
using System.Threading.Tasks;
using EternityStore.API.Models;

namespace EternityStore.API.Data
{
    public interface IProductCategoryRepository
    {
         void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();
        // a= there is somehting to get saved to database / b = there is an error to get saved to database
        Task<IEnumerable<ProductCategory>> GetProductCategories();

        Task<ProductCategory> GetProductCategory(int id);

        Task<IEnumerable<Product>> GetProductsBasedonCategory(int id);
    }
}