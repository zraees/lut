using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class OrderLine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        [ForeignKey("Order")]
        [Required]
        public ObjectId OrderID { get; set; }
        public virtual Order? Order { get; set; }

        [ForeignKey("Product")]
        [Required]
        [DisplayName("Product")]
        public ObjectId ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

    }
}
