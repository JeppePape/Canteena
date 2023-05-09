using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Models
{
    public class Ratings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int RatingId { get; set; }
        public int Rating { get; set; }
        public string CanteenName { get; set; }

        public string? AUID { get; set; }
    }
}
