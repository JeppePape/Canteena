using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Canteen.Models
{
    public class Canteena
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? CanteenName { get; set; }

        public float AvgRating { get; set; }

        public string PostCode { get; set; }



    }
}
