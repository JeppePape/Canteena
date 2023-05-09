using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? AUID { get; set; }
    }

}