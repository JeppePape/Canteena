using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ReservationId { get; set; }

        public string? CanteenName { get; set; }
        public string? AUID { get; set; }

        public string? MealName { get; set; }
    }
}
