using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        /// <summary>
        /// Get all products async
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ProductVO>> GetAllAsync();

        /// <summary>
        /// Get a product by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ProductVO> FindByIdAsync(long id);

        /// <summary>
        /// Create a new product async
        /// </summary>
        /// <param name="productVO"></param>
        /// <returns></returns>
        public Task<ProductVO> CreateAsync(ProductVO productVO);

        /// <summary>
        /// Update a product async
        /// </summary>
        /// <param name="productVO"></param>
        /// <returns></returns>
        public Task<ProductVO> UpdateAsync(ProductVO productVO);

        /// <summary>
        /// DEelete a product by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAsync(long id);
    }
}
