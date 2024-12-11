using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("User")]
        public ObjectId UserID { get; set; }
        public virtual UserAccount? User { get; set; }

        public ICollection<OrderLine>? Lines { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public required string DeliveryAddress { get; set; }
        [NotMapped]
        public decimal OrderValue { get; set; }
    }
}
