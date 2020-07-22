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

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();
            var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        } 

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repo.GetProduct(id);
            var productToReturn = _mapper.Map<ProductForDetailDto>(product);

            return Ok(productToReturn);
        }
    }


}