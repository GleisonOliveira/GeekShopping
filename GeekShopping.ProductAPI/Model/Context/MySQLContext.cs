using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    /// <summary>
    /// Create a db context do mysql
    /// </summary>
    public class MySQLContext: DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Roupas" });

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Camiseta", CategoryId = 1, Description ="Camiseta", Price = new decimal(5.0), ImageURL = "url" });
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
