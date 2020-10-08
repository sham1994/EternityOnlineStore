using EternityStore.Data.UnitOfWork;
using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.ProductCategoryBusiness
{
    public class ProductCategoryManager : IProductCategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductCategoryForListDto>> GetProductCategories()
        {
            return await _unitOfWork.ProductCategoryRepository.GetProductCategories();
        }

        public async Task<ProductCategoryForDetailDto> GetProductCategory(int id)
        {
            return await _unitOfWork.ProductCategoryRepository.GetProductCategory(id);
        }

        public async Task<IEnumerable<ProductForListDto>> GetProductsByCategory(int id)
        {
            return await _unitOfWork.ProductCategoryRepository.GetProductsByCategory(id);
        }  
    }
}
