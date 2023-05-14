using Canteen.Models;
using DnsClient;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;


namespace Canteen.Services
{
    public class RatingService
    {
        DBConnection db;
        private IMongoCollection<Ratings> Collection;
        private const string RatingCollection = "Rating";
        private readonly RatingService _ratings;
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

        public List<Ratings> GetRatings()
        {
            var ratings = Collection.Find(r => true).ToList();
            return ratings;
        }

        public List<Canteena> GetCanteenRatings()
        {
            var canteens = new List<Canteena>();
            var ratings = Collection.Find(new BsonDocument()).ToList();

            // Get a list of distinct canteen names from the ratings
            var canteenNames = ratings.Select(r => r.CanteenName).Distinct();

            foreach (var canteenName in canteenNames)
            {
                var canteenRatings = ratings.Where(r => r.CanteenName == canteenName).ToList();
                var canteenAvgRating = canteenRatings.Average(r => r.Rating);

                // Create a new Canteena object with the canteen name and average rating
                var canteen = new Canteena
                {
                    CanteenName = canteenName,
                    AvgRating = canteenAvgRating
                };

                canteens.Add(canteen);
            }

            // Sort the canteens by average rating in descending order
            return canteens.OrderByDescending(c => c.AvgRating).ToList();
        }

    }
}
