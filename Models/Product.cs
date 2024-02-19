using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required][StringLength(80)] public string Title { get; set; }

        [StringLength(50)] public string Subtitle { get; set; }

        [Required][StringLength(50)] public string Product_type { get; set; }

        [StringLength(300)] public string Description { get; set; }

        public List<string> Tags { get; set; }
    }
}