using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class DBConnection
    {
        private const string connectionString = "mongodb://root:example@localhost:27017";
        private const string databaseName = "Canteen";

        private MongoClient client;
        private IMongoDatabase db;

        public DBConnection()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

        }
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

        public MongoClient GetClient()
        {
            return client;
        }

        public IMongoDatabase GetDatabase()
        {
            return db;
        }
    }
}

