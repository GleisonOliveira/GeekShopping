using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductCategory Category { get; set; }

        public string ImageURL { get; set; }
    }
}
