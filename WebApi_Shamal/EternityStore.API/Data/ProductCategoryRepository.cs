using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EternityStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EternityStore.API.Data
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext _context;
        public ProductCategoryRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
             var categories = await _context.ProductCategories.Include(p => p.CategoryPhotos).ToListAsync();

            return categories;
        }

        public async Task<ProductCategory> GetProductCategory(int id)
        {
            var category = await _context.ProductCategories.Include(p => p.CategoryPhotos).FirstOrDefaultAsync(c => c.Id == id);

           return category;
        }

        public async Task<IEnumerable<Product>> GetProductsBasedonCategory(int id) 
        {
            var products = await _context.Products.Where(c=>c.ProductCategoryId == id).Include(p => p.ProductPhotos).ToListAsync();
            return products;
            
    
        } 

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}