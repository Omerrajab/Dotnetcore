using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Findry.Data.Entities
{
  
        public class Product
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            [MaxLength(500)]
            public string Description { get; set; }

            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal Price { get; set; }

            [Required]
            public int StockQuantity { get; set; }

            [Required]
            public int CategoryId { get; set; } // Foreign key to Category

            [ForeignKey("CategoryId")]
            public virtual Category Category { get; set; } // Navigation property to Category

            // Optional additional properties, such as:
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public bool IsActive { get; set; } = true;
        }
}
