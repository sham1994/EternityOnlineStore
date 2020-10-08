using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.ProductsBusiness
{
    public interface IProductManager
    {
        Task<ProductForDetailDto> GetProduct(int id);

        Task<IEnumerable<ProductForListDto>> GetProducts();





    }
}
