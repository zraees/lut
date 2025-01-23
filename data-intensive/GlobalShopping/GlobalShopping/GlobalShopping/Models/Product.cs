using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class Product
    {
        public int? ID { get; set; }
        public required string Name { get; set; }

        public required string Category { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Manufactured date")]
        public DateTime ManufactureDate { get; set; }
        [NotMapped]
        [DisplayName("Image")]
        public IFormFile? ProductImage { get; set; } = null!;
        [NotMapped]
        public byte[]? Image
        {
            get; set;
        }
        public bool Active { get; set; } = true;
        [NotMapped]
        [DisplayName("Stock Qty")]
        public decimal StockQuantity { get; set; }
    }
}
