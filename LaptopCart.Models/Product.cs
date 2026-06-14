using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopCart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        public string Name { get; set; } = null!;
        [StringLength(500, ErrorMessage ="Description cannot be greater than 500 characters")]
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
