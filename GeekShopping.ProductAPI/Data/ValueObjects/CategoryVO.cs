using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    public class CategoryVO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
