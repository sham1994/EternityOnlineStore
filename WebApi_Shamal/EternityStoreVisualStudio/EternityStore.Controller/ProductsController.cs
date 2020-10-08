using AutoMapper;
using EternityStore.Business.ProductsBusiness;
using EternityStore.Entity;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productsManager;
        private readonly IMapper _mapper;

        public ProductsController(IProductManager productsManager, IMapper mapper)
        {
            _productsManager = productsManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
         var products = await _productsManager.GetProducts();
         var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

         return Ok(productsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductForDetailDto product = await _productsManager.GetProduct(id);
            return Ok(product);
        }
    }


}