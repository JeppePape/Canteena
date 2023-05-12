using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class StaffService
    {
        DBConnection db;
        private IMongoCollection<Staff> Collection;
        private const string StaffCollection = "Staff";
       

        public StaffService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Staff>(StaffCollection);
        }

        public void CreateStaff(Staff staff)
        {
            Collection.InsertOne(staff);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(StaffCollection);
        }
        public List<Staff> GetStaffByCanteenName(string canteenName)
        { 
        var filter = Builders<Staff>.Filter.Eq(x => x.CanteenName, canteenName);
            var result = Collection.Find(filter).ToList();
            return result;
        }



    }
}
