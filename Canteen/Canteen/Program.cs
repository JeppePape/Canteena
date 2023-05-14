using Canteen.Models;
using Canteen.Services;
using System;
using System.Diagnostics;

namespace Canteen
{
    public class program
    {

        public static DBConnection db = new DBConnection();
        public static CanteenService _canteen = new CanteenService(db);
        public static CustomerService _customer = new CustomerService(db);
        public static MenuService _menu = new MenuService(db);
        public static RatingService _rating = new RatingService(db);
        public static ReservationService _reservation = new ReservationService(db);
        //public static ReservationlistService _reservationlist = new ReservationlistService(db);
        public static StaffService _staff = new StaffService(db);

        static void Main(string[] args)
        {


            Console.WriteLine("Påbegynd Handin 3");
            Console.WriteLine("\n" + "Smid hele databasen og reseed data Y/N ?)");
            ConsoleKeyInfo cki1 = Console.ReadKey();
            if (cki1.KeyChar == 'Y')
            {
                SeedData();
                Console.WriteLine("\n" + "Data Seeded");
            }

            while (true)
            {
                Console.WriteLine("\n" + "Vis Query 1(1) Query 2(2), Query 3(3), Query 4(4), Query 5(5) , Query 6(6)");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.KeyChar == '1' || consoleKeyInfo.KeyChar == '2' || consoleKeyInfo.KeyChar == '3' ||
                    consoleKeyInfo.KeyChar == '4' || consoleKeyInfo.KeyChar == '5' || consoleKeyInfo.KeyChar == '6')
                {
                    Console.WriteLine();
                    ChooseQuery(consoleKeyInfo.KeyChar);
                }

                else
                {
                    return;
                }

            }
        }

        static void ChooseQuery(char c)
        {
            switch (c)
            {
                case '1':
                    //Query 1: get the menu options for a given canteen
                    Console.WriteLine("Enter the canteen name:");
                    var canteenName = Console.ReadLine();

                    var menus = _menu.GetMenuByCanteenName(canteenName);
                    foreach (var menu in menus)
                    {
                        Console.WriteLine("Street Foods:");
                        foreach (var sf in menu.streetFoods)
                        {
                            Console.WriteLine(sf.Name);
                        }
                        Console.WriteLine("Warm Dishes:");
                        foreach (var wd in menu.warmDishes)
                        {
                            Console.WriteLine(wd.Name);
                        }
                    }
                    break;

                case '2':
                    //Query 2 : Get the reservation for a given user  AUID

                    Console.WriteLine("Enter Your AUID:");
                    var AUID = Console.ReadLine();
                    var reservationslist = _reservation.GetReservationsByAUID(AUID);
                    Console.WriteLine("Meal Id\tName\tCanteen Name");
                    foreach (var reservation in reservationslist)
                    {
                        Console.WriteLine($"{reservation.ReservationId}\t{reservation.MealName}\t{reservation.CanteenName}");
                    }
                    break;

                case '3':
                    //Query 3 : For a canteen given as input, show the number of reservations for each of the daily menu options (E.g. For Kgl. Bibliotek):   

                    Console.WriteLine("Enter the CanteenName :");
                    var CanteenName = Console.ReadLine();

                    var reservations = _reservation.GetReservationCountByCanteen(CanteenName);

                    var mealCounts = reservations
                        .GroupBy(r => r.MealName)
                        .Select(g => new { Name = g.Key, Amount = g.Count() });

                    Console.WriteLine($"Reservations for {CanteenName}:");
                    Console.WriteLine("Name\t\tAmount");
                    foreach (var mealCount in mealCounts)
                    {
                        Console.WriteLine($"{mealCount.Name}\t\t{mealCount.Amount}");
                    }
                    break;

                case '4':
                    // Query 5: For a canteen given as input, show the the available
                    // (canceled) daily menu in the nearby canteens (E.g. For Kgl. Bibliotek):


                    break;
                case '5':
                    //Query 5: Show the average ratings from all the canteens from top to bottom (E.g.)

                    break;
                case '6':
                    // Query 6 : For a canteen given as input, show the payroll of its staff members (E.g.: For Kgl. Bibliotek):
                    Console.WriteLine("Enter the canteen name:");
                    var canteenNames = Console.ReadLine();
                    var _staffmembers = _staff.GetStaffByCanteenName(canteenNames);
                    Console.WriteLine("StaffID\t\tName\t\tSalary\t\tTitle");
                    foreach (var staff in _staffmembers)
                    {
                        Console.WriteLine("{0,-15}\t{1,-10}\t{2,-15}\t{3}", staff.StaffID, staff.Name, staff.Title, staff.Salary);
                    }
                    break;

            }
        }

        public static void SeedData()
        {
            _canteen.DropCollection();
            _customer.DropCollection();
            _menu.DropCollection();
            _rating.DropCollection();
            _reservation.DropCollection();
            _staff.DropCollection();

            Canteena canteen1 = new Canteena()
            {
                CanteenName = "Canteen 1",
                AvgRating = 4,
                PostCode = "9000",

            };
            Canteena canteen2 = new Canteena()
            {
                CanteenName = "Canteen 2",
                AvgRating = 3,
                PostCode = "8000",

            };
            Canteena canteen3 = new Canteena()
            {
                CanteenName = "Canteen 3",
                AvgRating = 2,
                PostCode = "7000",

            };
            _canteen.CreateCanteen(canteen1); _canteen.CreateCanteen(canteen2); _canteen.CreateCanteen(canteen3);

            Customer customer1 = new Customer()
            {
                AUID = "000420"
            };
            Customer customer2 = new Customer()
            {
                AUID = "000069"
            };
            Customer customer3 = new Customer()
            {
                AUID = "001337"
            };
            _customer.CreateCustomer(customer1); _customer.CreateCustomer(customer2); _customer.CreateCustomer(customer3);
            Staff staff1 = new Staff()
            {
                StaffID = 4,
                Name = "Jens B.",
                Title = "Cook",
                Salary = 30700,
                CanteenName = "Canteen 1"
            };
            Staff staff2 = new Staff()
            {
                StaffID = 5,
                Name = "Mette C.",
                Title = "Waiter",
                Salary = 29000,
                CanteenName = "Canteen 1"
            };
            Staff staff3 = new Staff()
            {
                StaffID = 6,
                Name = "Mads D.",
                Title = "Waiter",
                Salary = 29000,
                CanteenName = "Canteen 1"
            };
            Staff staff4 = new Staff()
            {
                StaffID = 7,
                Name = "Lucile E.",
                Title = "Cook",
                Salary = 30700,
                CanteenName = "Canteen 1"
            };
            _staff.CreateStaff(staff1); _staff.CreateStaff(staff2); _staff.CreateStaff(staff3); _staff.CreateStaff(staff4);

            Ratings rating1 = new Ratings()
            {
                Rating = 4,
                CanteenName = "Canteen 1",
                AUID = "000420"
            };
            Ratings rating2 = new Ratings()
            {
                Rating = 3,
                CanteenName = "Canteen 2",
                AUID = "000069"
            };
            Ratings rating3 = new Ratings()
            {
                Rating = 2,
                CanteenName = "Canteen 3",
                AUID = "001337"
            };
            Ratings rating4 = new Ratings()
            {
                Rating = 4,
                CanteenName = "Canteen 1",
                AUID = "000420"
            };
            Ratings rating5 = new Ratings()
            {
                Rating = 3,
                CanteenName = "Canteen 2",
                AUID = "000069"
            };
            Ratings rating6 = new Ratings()
            {
                Rating = 2,
                CanteenName = "Canteen 3",
                AUID = "001337"
            };
            _rating.CreateRating(rating1); _rating.CreateRating(rating2); _rating.CreateRating(rating3); _rating.CreateRating(rating4); _rating.CreateRating(rating5); _rating.CreateRating(rating6);

            Reservation reservation1 = new Reservation()
            {
                ReservationId = 1,
                CanteenName = "Canteen 1",
                AUID = "000420",
                MealName = "Kebab"
            };
            Reservation reservation2 = new Reservation()
            {
                ReservationId = 2,
                CanteenName = "Canteen 3",
                AUID = "000069",
                MealName = "Pita"
            };
            Reservation reservation3 = new Reservation()
            {
                ReservationId = 3,
                CanteenName = "Canteen 3",
                AUID = "001337",
                MealName = "Soup"
            };
            Reservation reservation4 = new Reservation()
            {
                ReservationId = 4,
                CanteenName = "Canteen 2",
                AUID = "000420",
                MealName = "Gulash"
            };
            _reservation.CreateReservation(reservation1); _reservation.CreateReservation(reservation2); _reservation.CreateReservation(reservation3); _reservation.CreateReservation(reservation4);




            //Seeding Menu data 
            var streetFood1 = new StreetFood
            {
                Name = "Burger"
            };

            var streetFood2 = new StreetFood
            {
                Name = "Taco"
            };

            var warDish1 = new WarmDish
            {
                Name = "Lasagna"
            };

            var warDish2 = new WarmDish
            {
                Name = "Chicken Curry"
            };
            //_menu.CreateMenu(streetFood1); _menu.CreateMenu(streetFood1); _menu.CreateMenu(warDish1);_menu.CreateMenu(warDish2);

            var reservationMenu1 = new ReservationMenu()
            {
                CanteenName = "Canteen 1",
                streetFoods = new List<StreetFood> { },
                warmDishes = new List<WarmDish> { },
            };
            var reservationMenu2 = new ReservationMenu()
            {
                CanteenName = "Canteen 2",
                streetFoods = new List<StreetFood> { },
                warmDishes = new List<WarmDish> { },
            };

            reservationMenu1.streetFoods.Add(streetFood1); reservationMenu2.streetFoods.Add(streetFood2);

            reservationMenu1.warmDishes.Add(warDish1); reservationMenu2.warmDishes.Add(warDish2);

            _menu.CreateMenu(reservationMenu1); _menu.CreateMenu(reservationMenu2);





        }
    }
}