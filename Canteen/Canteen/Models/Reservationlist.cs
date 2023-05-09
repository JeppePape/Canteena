using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Models
{
    public class Reservationlist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? CanteenName { get; set; }
        public string? MealName { get; set; }
    }
}
