using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class RatingService
    {
        DBConnection db;
        private IMongoCollection<Ratings> Collection;
        private const string RatingCollection = "Rating";
        public RatingService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Ratings>(RatingCollection);
        }

        public void CreateRating(Ratings rating)
        {
            Collection.InsertOne(rating);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(RatingCollection);
        }
    }
}
