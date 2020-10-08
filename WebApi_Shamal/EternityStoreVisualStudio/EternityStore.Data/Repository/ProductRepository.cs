using AutoMapper;
using EternityStore.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<ProductForDetailDto> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.ProductPhotos).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ProductForDetailDto> (product);

           
        } 

        public async Task<IList<ProductForListDto>> GetProducts()
        {
            var product = await _context.Products.Include(p => p.ProductPhotos).ToListAsync();
           return _mapper.Map<List<ProductForListDto>>(product);

           
        }

        public async Task<bool> SaveAll()
        {
             return await _context.SaveChangesAsync() > 0;
        }
    }
}