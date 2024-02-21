using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Subtitle { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_type { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public float full_price { get; set; }

        [DefaultValue(0)]
        public int quantity { get; set; }

        public List<string> Tags { get; set; }

        // public int CategoryId { get; set; }

        // public Category? Category { get; set; }
    }
}