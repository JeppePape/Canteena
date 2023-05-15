using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Canteen.Models
{
    public class ReservationMenu
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? MenuId { get; set; }

        public List<StreetFood> streetFoods { get; set; }
        public List <WarmDish> warmDishes { get; set; }

        public string? CanteenName { get; set; }
    }

    public class StreetFood
    {
        [BsonElement("StreetFoodName")]
        public string? Name { get; set; }

    }

    public class WarmDish
    {
        [BsonElement("WarmDishName")]
        public string? Name { get; set; }
    }

    public class CanceledMeals
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CanceledName")]
        public string? CanceledMealsName { get; set; }
        public string? CanteenName { get; set; }

    }
}
