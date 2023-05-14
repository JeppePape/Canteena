//using Canteen.Models;
//using MongoDB.Driver;

//namespace Canteen.Services
//{
//    public class ReservationlistService
//    {
//        DBConnection db;
//        private IMongoCollection<Reservationlist> Collection;
//        private const string ReservationListCollection = "ReservationList";
//        private readonly IMongoCollection<Reservation> _reservationService;
//        public ReservationlistService(DBConnection db)
//        {
//            this.db = db;
//            Collection = db.ConnectToMongo<Reservationlist>(ReservationListCollection);
//        }

//        public void CreateReservationlist(Reservationlist list)
//        {
//            Collection.InsertOne(list);
//        }

//        public void DropCollection()
//        {
//            var database = db.GetDatabase();
//            database.DropCollection(ReservationListCollection);
//        }

//        public List<Reservationlist> InserIntotReservationsList(List<Reservation> reservations)
//        {
//            var database = db.GetDatabase();
//            var collection = database.GetCollection<Reservation>("Reservation");
//            var sortedReservations = reservations.OrderBy(x => x.CanteenName);
//            var reservationList = new List<Reservationlist>();
//            foreach (var reservation in sortedReservations)
//            {
//                reservationList.Add(new Reservationlist()
//                {
//                    Id = reservation.Id,
//                    CanteenName = reservation.CanteenName,
//                    MealName = reservation.MealName
//                });
//            }
//            return reservationList;
//        }


//    }
//}