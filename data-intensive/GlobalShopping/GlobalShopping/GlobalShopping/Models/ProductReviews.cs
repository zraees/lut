﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GlobalShopping.Models
{
    public class ProductReview
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ID { get; set; }

        [BsonElement("Review")]
        public string Review { get; set; } = null!;
        public ObjectId ProductID { get; set; }
    }
}
