using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Repository
{
    /// <summary>
    /// Define the methods to be implemented in repository
    /// </summary>
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductVO>> GetAllAsync();
        public Task<ProductVO> FindByIdAsync(long id);
        public Task<ProductVO> CreateAsync(ProductVO productVO); 
        public Task<ProductVO> UpdateAsync(ProductVO productVO);
        public Task DeleteAsync(long id);
    }
}
