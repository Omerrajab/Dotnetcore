using Findry.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Findry.Data.Entities
{
  
        public class Category
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            [MaxLength(500)]
            public string Description { get; set; }

            // Navigation property for related products
            public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        }

}
