using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();

                config.CreateMap<CategoryVO, Category>();
                config.CreateMap<Category, CategoryVO>();

                config.CreateMap<Category, ProductCategory>();
            });
            
            return mappingConfig;
        }
    }
}
