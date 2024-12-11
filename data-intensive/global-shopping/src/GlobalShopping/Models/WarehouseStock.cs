using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalShopping.Models
{
    public class WarehouseStock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();

        [ForeignKey("Product")]
        [Required]
        [DisplayName("Product")]
        public ObjectId ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [Required]
        public decimal AvailableQty { get; set; }
    }
}
