using Canteen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class CancelService
    {
        private DBConnection db;
        private readonly IMongoCollection<CanceledMeals> Collection;
        private const string CancelCollection = "Cancel";




        public CancelService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<CanceledMeals>(CancelCollection);
        }

        public void CreateCancel(CanceledMeals Canceled)
        {
            Collection.InsertOne(Canceled);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(CancelCollection);
        }

        public List<CanceledMeals> GetCanceledMealsExceptCanteen(string canteenName)
        {
            var filter = Builders<CanceledMeals>.Filter.Ne(cm => cm.CanteenName, canteenName);
            var canceledMeals = Collection.Find(filter).ToList();
            return canceledMeals;
        }
    }
}
