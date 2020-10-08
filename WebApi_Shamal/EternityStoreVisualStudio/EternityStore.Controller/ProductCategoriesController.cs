using AutoMapper;
using EternityStore.Business.ProductCategoryBusiness;
using EternityStore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryManager _productCategoryManager;
        private readonly IMapper _mapper;
        public ProductCategoriesController(IProductCategoryManager productCategoryManager, IMapper mapper)
        {
            _productCategoryManager = productCategoryManager;
            _mapper = mapper;
            

        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await _productCategoryManager.GetProductCategories();
            var categoriesToReturn = _mapper.Map<IEnumerable<ProductCategoryForListDto>>(categories);
            return Ok(categoriesToReturn);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetProductCategory(int id)
        {
            var category = await _productCategoryManager.GetProductCategory(id);

            var categoryToReturn = _mapper.Map<ProductCategoryForDetailDto>(category);

            return Ok(categoryToReturn);
        }

        [HttpGet("pbc/{id}")] 
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var products = await _productCategoryManager.GetProductsByCategory(id);

            var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        }
    }
}