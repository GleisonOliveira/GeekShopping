using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    [Table("category")]
    public class Category: BaseEntity
    {
        [Required]
        [StringLength(255)]
        [Column("name")]
        public string Name { get; set; }
    }
}
