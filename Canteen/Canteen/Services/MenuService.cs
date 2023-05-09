using Canteen.Models;
using MongoDB.Driver;

namespace Canteen.Services
{
    public class MenuService
    {
        DBConnection db;
        private IMongoCollection<ReservationMenu> Collection;
        private const string MenuCollection = "Menu";

        public MenuService(DBConnection db)
        {
            this.db = db;
            Collection = db.ConnectToMongo<ReservationMenu>(MenuCollection);
        }

        public void CreateMenu(ReservationMenu menu)
        {
            Collection.InsertOne(menu);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(MenuCollection);
        }
    }
}
