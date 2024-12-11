using GlobalShopping.Models;
using MongoDB.Driver;

namespace GlobalShopping.Services
{
    public class MongoHelperService
    {
        private readonly IMongoCollection<ProductImage> _productCollection;
        public MongoHelperService(IMongoDatabase database)
        {
            _productCollection = database.GetCollection<ProductImage>("ProductImages");
        }
    }
}
