using Canteen.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.Design;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //public List<ReservationMenu> GetMenuByCanteenName(string canteenName)
        //{
        //    var filter = Builders<ReservationMenu>.Filter.Eq(x => x.CanteenName, canteenName);
        //    var projection = Builders<ReservationMenu>.Projection.Exclude(x => x.warmDishes).Exclude(x => x.streetFoods).Exclude(x => x.CanteenName).Exclude(x => x.MenuId);
        //    var result = Collection.Find(filter).Project<ReservationMenu>(projection).ToList();


        //    return result; 

        //}

        public List<ReservationMenu> GetMenuByCanteenName(string canteenName)
        {
            var database = db.GetDatabase();
            var collection = database.GetCollection<ReservationMenu>("Menu");
            
            var menucanteen = Collection.Find(m => m.CanteenName == canteenName).ToList();
       

            return menucanteen;
        }

    }
}
