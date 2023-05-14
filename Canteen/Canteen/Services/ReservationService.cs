using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class ReservationService
    {
        DBConnection db;
        private IMongoCollection<Reservation> Collection;
        private const string ReservationCollection = "Reservation";

        public ReservationService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<Reservation>(ReservationCollection);
        }

        public void CreateReservation(Reservation reservation)
        {
            Collection.InsertOne(reservation);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(ReservationCollection);
        }
        public IMongoCollection<Reservation> GetCollection()
        {
            return Collection;
        }
        public List <Reservation> GetReservationCountByCanteen(string CanteenName)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.CanteenName, CanteenName);
            var reservations = Collection.Find(filter).ToList();
            return reservations;
        }


        public List<Reservation> GetReservationsByAUID(string AuId)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.AUID, AuId);
            var reservations = Collection.Find(filter).ToList();
            return reservations;
        }


    }
}
