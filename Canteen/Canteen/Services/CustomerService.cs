using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class CustomerService
    {
        DBConnection db;
        private IMongoCollection<Customer> Collection;
        private const string CustomerCollection = "Customer";

        public CustomerService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Customer>(CustomerCollection);
        }

        public void CreateCustomer(Customer customer)
        {
            Collection.InsertOne(customer);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(CustomerCollection);
        }
    }
}
