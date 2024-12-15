using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class OrderLine
    {
        public int? ID { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderID { get; set; }
        public virtual Order? Order { get; set; }

        [ForeignKey("Product")]
        [Required]
        [DisplayName("Product")]
        public int ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

    }
}
