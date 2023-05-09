using MongoDB.Driver;
using Canteen.Models;
using Microsoft.Extensions;
using System.Diagnostics;

namespace Canteen.Services
{
    public class CanteenService
    {
        private DBConnection db;
        private readonly IMongoCollection<Canteena> _CanteenCollection;
        private const string CanteenCollection = "Canteen";




        public CanteenService(DBConnection db)
        {
            this.db = db;
            _CanteenCollection = db.ConnectToMongo<Canteena>(CanteenCollection);
        }

        public void CreateCanteen(Canteena canteen)
        {
            _CanteenCollection.InsertOne(canteen);
        }

        public void DropCollection()
        {
            var database = db.GetDatabase();
            database.DropCollection(CanteenCollection);
        }

        //public void GetBookedFacilitiesBookingUserTime()
        //{
        //    List<Canteen> activities = _CanteenCollection.Find(canteen => true).ToList();

        //    foreach (var canteen in activities)
        //    {
        //        Console.WriteLine($"Booking User: {canteen.Citizen.Name}, Facility Name: {Canteen.Facility.Name}, Timeslot: from {Canteen.StartTime} to {Canteen.EndTime}");
        //    }
        //}

        //public void GetBookingsWithParticipants()
        //{
        //    List<Canteen> activities = Collection.Find(Canteen => true).ToList();

        //    foreach (var Canteen in activities)
        //    {
        //        Console.WriteLine($"Facility Name: {Canteen.Facility.Name}, Timeslot: from {Canteen.StartTime} to {Canteen.EndTime}, Paticipants");
        //        var temp = Canteen.Participants;

        //        foreach (var act in temp)
        //        {
        //            Console.WriteLine(act.Cpr);
        //        }
        //    }
        //}

        //public void AddParticipant(Canteen Canteen, Participant participant)
        //{
        //    Console.WriteLine($"Acitivity ID: {Canteen.CanteenId}");
        //    Canteen.Participants.Add(participant);
        }

        //public CanteenService(IOptions<CanteenDatabaseSettings> canteenDatabaseSettings)

        //{
        //    var mongoClient = new MongoClient(
        //        canteenDatabaseSettings.Value.ConnectionString);
        //    var mongoDatabase = mongoClient.GetDatabase(
        //        canteenDatabaseSettings.Value.DatabaseName);
        //    _CanteenCollection = mongoDatabase.GetCollection<Canteen>(
        //        canteenDatabaseSettings.Value.CanteenCollectionName);
        //}

        //public async Task<List<Canteen>> GetAsync() =>
        //    await _CanteenCollection.Find(_ => true).ToListAsync();
        //public async Task<Canteen?> GetAsync(string id) =>
        //    await _CanteenCollection.Find<Canteen>(canteen => canteen.CanteenName == id).FirstOrDefaultAsync();
        //public async Task CreateAsync(Canteen newCanteen) =>
        //    await _CanteenCollection.InsertOneAsync(newCanteen);

        //public async Task UpdateAsync(string id, Canteen updatedCanteen) =>
        //    await _CanteenCollection.ReplaceOneAsync(x => x.CanteenName == id, updatedCanteen);

        //public async Task RemoveAsync(string id) =>
        //    await _CanteenCollection.DeleteOneAsync(x => x.CanteenName == id);
    }

