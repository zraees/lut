using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GlobalShopping.Models
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public byte[] Image { get; set; } = null!;
        public int? ProductID { get; set; }
    }
}
