using AutoMapper;
using EternityStore.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductCategoryForListDto>> GetProductCategories()
        {
             var categories = await _context.ProductCategories.Include(p => p.CategoryPhotos).ToListAsync();
            return _mapper.Map<IEnumerable<ProductCategoryForListDto>>(categories);

            
        }

        public async Task<ProductCategoryForDetailDto> GetProductCategory(int id)
        {
            var category = await _context.ProductCategories.Include(p => p.CategoryPhotos).FirstOrDefaultAsync(c => c.Id == id);
           return _mapper.Map<ProductCategoryForDetailDto>(category);
        }

        public async Task<IEnumerable<ProductForListDto>> GetProductsByCategory(int id) 
        {
            var products = await _context.Products.Where(c=>c.ProductCategoryId == id).Include(p => p.ProductPhotos).ToListAsync();
            return _mapper.Map<IEnumerable<ProductForListDto>>(products);
            
    
        } 

        
    }
}