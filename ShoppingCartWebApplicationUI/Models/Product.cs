using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartWebApplicationUI.Models
{
    [Table("Product")]
    public class Product
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? ProductName { get; set; }
        [Required]
        [MaxLength(40)]
        public string? VendorName { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; } = "noimage.png";
        [Required]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
        public List<CartDetail>? CartDetail { get; set; }

        [NotMapped]
        public string? GenreName { get; set; }
    }
}
