using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AUID { get; set; }
    }

}