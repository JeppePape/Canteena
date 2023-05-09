using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class ReservationlistService
    {
        DBConnection db;
        private IMongoCollection<Reservationlist> Collection;
        private const string ReservationListCollection = "ReservationList";
        public ReservationlistService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Reservationlist>(ReservationListCollection);
        }

        public void CreateReservationlist(Reservationlist list)
        {
            Collection.InsertOne(list);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(ReservationListCollection);
        }
    }
}
