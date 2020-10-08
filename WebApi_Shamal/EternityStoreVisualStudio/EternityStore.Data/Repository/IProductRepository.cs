using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public interface IProductRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();
        // a= there is somehting to get saved to database / b = there is an error to get saved to database
        Task<IList<ProductForListDto>> GetProducts();

        Task<ProductForDetailDto> GetProduct(int id);
    }
}