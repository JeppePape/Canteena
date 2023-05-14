using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Models
{
    public class Ratings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int RatingId { get; set; }
        public float Rating { get; set; }
        public string CanteenName { get; set; }

        public string? AUID { get; set; }
    }
}
