using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Models
{
    public class ReservationMenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? MenuId { get; set; }

        [BsonElement("Name")]

        public string? CanteenName { get; set; }
        public string Canteen { get; set; }
    }

    public class StreeFood : ReservationMenu
    {
        public string? Name { get; set; }
    }

    public class WarDish : ReservationMenu
    {
        public string? Name { get; set; }
    }

    public class CanceledMeals
    {
        public string? CanceledMealsName { get; set; }
        public string? CanteenName { get; set; }
        public string? Canteen { get; set; }
    }
}
