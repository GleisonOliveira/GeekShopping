using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    /// <summary>
    /// Represent a category in db
    /// </summary>
    [Table("category")]
    public class Category: BaseEntity
    {
        [Required()]
        [StringLength(255)]
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
