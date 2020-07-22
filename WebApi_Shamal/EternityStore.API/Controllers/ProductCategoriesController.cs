using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EternityStore.API.Data;
using EternityStore.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EternityStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryRepository _repo;
        private readonly IMapper _mapper;
        public ProductCategoriesController(IProductCategoryRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await _repo.GetProductCategories();
            var categoriesToReturn = _mapper.Map<IEnumerable<ProductCategoryForListDto>>(categories);
            return Ok(categoriesToReturn);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetProductCategory(int id)
        {
            var category = await _repo.GetProductCategory(id);

            var categoryToReturn = _mapper.Map<ProductCategoryForDetailDto>(category);

            return Ok(categoryToReturn);
        }

        [HttpGet("pbc/{id}")] 
        public async Task<IActionResult> GetProductsBasedonCategory(int id)
        {
            var products = await _repo.GetProductsBasedonCategory(id);

            var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        }
    }
}