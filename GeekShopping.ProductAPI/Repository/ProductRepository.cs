using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Exceptions;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    /// <summary>
    /// Manage all db operations to entitie
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new instance of product
        /// </summary>
        /// <param name="productVO"></param>
        /// <returns></returns>
        public async Task<ProductVO> CreateAsync(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task DeleteAsync(long id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new NotFoundException("product", nameof(DeleteAsync), "ProductRepository");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Find all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductVO>> GetAllAsync()
        {
            return _mapper.Map<List<ProductVO>>(
                await _context.Products.Include(x => x.Category).ToListAsync()
            );
        }

        /// <summary>
        /// Find a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<ProductVO> FindByIdAsync(long id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(product == null)
            {
                throw new NotFoundException("product", nameof(FindByIdAsync), "ProductRepository");
            }

            return _mapper.Map<ProductVO>(
                await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync()
            );
        }

        public async Task<ProductVO> UpdateAsync(ProductVO productVO)
        {
            Product product = _mapper.Map<Product>(productVO);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }
    }
}
