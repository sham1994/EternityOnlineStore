using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public interface IProductCategoryRepository
    {
       
        Task<IEnumerable<ProductCategoryForListDto>> GetProductCategories();

        Task<ProductCategoryForDetailDto> GetProductCategory(int id);

        Task<IEnumerable<ProductForListDto>> GetProductsByCategory(int id);
    }
}