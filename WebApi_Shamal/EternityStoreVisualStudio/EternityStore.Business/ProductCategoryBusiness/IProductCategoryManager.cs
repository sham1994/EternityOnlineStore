using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.ProductCategoryBusiness
{
    public interface IProductCategoryManager
    {
        Task<ProductCategoryForDetailDto> GetProductCategory(int id);
        Task<IEnumerable<ProductCategoryForListDto>> GetProductCategories();

        Task<IEnumerable<ProductForListDto>> GetProductsByCategory(int id);


    }
}
