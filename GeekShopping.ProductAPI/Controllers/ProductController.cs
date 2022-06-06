using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    /// <summary>
    /// This endpoint controll all operations of product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        /// <summary>
        /// Get a specific product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            return Ok(await _productRepository.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            return CreatedAtRoute(nameof(Create),await _productRepository.CreateAsync(productVO));
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO)
        {
            return Ok(await _productRepository.UpdateAsync(productVO));
        }

        [HttpDelete]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            await _productRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
