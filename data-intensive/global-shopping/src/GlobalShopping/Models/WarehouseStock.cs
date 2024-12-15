using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class WarehouseStock
    {
        public int? ID { get; set; }

        [ForeignKey("Product")]
        [Required]
        [DisplayName("Product")]
        public int? ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [Required]
        public decimal AvailableQty { get; set; }
    }
}
