using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int ReservationId { get; set; }

        public string? CanteenName { get; set; }
        public string? AUID { get; set; }

        public string? MealName { get; set; }
    }
}
