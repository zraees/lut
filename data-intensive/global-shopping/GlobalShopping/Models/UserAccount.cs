using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace GlobalShopping.Models
{
    public class UserAccount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; } = true;
    }
}
