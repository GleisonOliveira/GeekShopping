using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    /// <summary>
    /// Represent a product in db
    /// </summary>
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        [Column("price")]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public Category Category { get; set; }

        [Column("image_url")]
        [StringLength(255)]
        public string ImageURL { get; set; }
    }
}
