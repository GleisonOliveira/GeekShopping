using GeekShopping.Web.Exceptions;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using System.Net.Http.Json;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductVO> CreateAsync(ProductVO productVO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVO> FindByIdAsync(long id)
        {
            try
            {
                return await _client.GetFromJsonAsync<ProductVO>($"{BasePath}/{id}");
            }
            catch (HttpRequestException ex)
            {
                throw new ServiceUnavailableException("product", nameof(GetAllAsync), "ProductService");
            }
        }

        public async Task<IEnumerable<ProductVO>> GetAllAsync()
        {
            try
            {
                return await _client.GetFromJsonAsync<List<ProductVO>>(BasePath);
            }
            catch (HttpRequestException ex)
            {
                throw new ServiceUnavailableException("product", nameof(GetAllAsync), "ProductService");
            }
        }

        public Task<ProductVO> UpdateAsync(ProductVO productVO)
        {
            throw new NotImplementedException();
        }
    }
}
