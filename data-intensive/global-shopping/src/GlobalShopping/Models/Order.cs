using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class Order
    {
        public int? ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Order date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserID { get; set; }
        public virtual UserAccount? User { get; set; }

        public ICollection<OrderLine>? Lines { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        [DisplayName("Delivery address")]
        public required string DeliveryAddress { get; set; }
        [NotMapped]
        [DisplayName("Order value")]
        public decimal OrderValue { get; set; }
    }
}
