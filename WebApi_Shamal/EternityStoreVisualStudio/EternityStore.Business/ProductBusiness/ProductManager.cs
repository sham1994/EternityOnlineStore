using EternityStore.Data.UnitOfWork;
using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.ProductsBusiness
{
    public class ProductManager : IProductManager
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductForDetailDto> GetProduct(int id)
        {
          return  await _unitOfWork.ProductRepository.GetProduct(id);
        }

        public async Task<IEnumerable<ProductForListDto>> GetProducts()
        {
            return await _unitOfWork.ProductRepository.GetProducts();
        }
    }
}
