using MongoDB.Driver;
using Canteen.Models;
using Microsoft.Extensions;
using System.Diagnostics;

namespace Canteen.Services
{
    public class CanteenService
    {
        private DBConnection db;
        private readonly IMongoCollection<Canteena> Collection;
        //private readonly string connectionString = "mongodb://root:example@localhost:27017";
        private const string CanteenCollection = "Canteen";
        //private const string databaseName = "Canteen";
        //private IMongoDatabase database;



        public CanteenService(DBConnection db)
        {
            //var client = new MongoClient(connectionString);
            //database = client.GetDatabase(databaseName);
            //_Collection = database.GetCollection<Canteena>(Collection);
            this.db = db;
            Collection = db.ConnectToMongo<Canteena>(CanteenCollection);
        }

        public void CreateCanteen(Canteena canteen)
        {
            Collection.InsertOne(canteen);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(CanteenCollection);
            //database.DropCollection(Collection);
        }
    }
}
