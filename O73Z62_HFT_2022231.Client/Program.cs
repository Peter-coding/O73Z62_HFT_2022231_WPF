using ConsoleTools;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O73Z62_HFT_2022231.Client
{
    static class MyExtension
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"*** {header} ***");
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"***");
            Console.ReadLine();
        }
    }
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter Company Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Company Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Company PhoneNumber: ");
                string phoneNumber = Console.ReadLine();
                rest.Post(new Company() { Name = name, Email = email, PhoneNumber = phoneNumber }, "company");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter Car Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Car Brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter Car Engine Type: ");
                string engine = Console.ReadLine();
                Console.Write("Enter Car Cylinder Capacity: ");
                int cc = int.Parse(Console.ReadLine());
                Console.Write("Enter Car Monthly Price: ");
                int mp = int.Parse(Console.ReadLine());
                Console.Write("Enter Car Power: ");
                int power = int.Parse(Console.ReadLine());
                rest.Post(new Car() { Name = name, Brand = brand, Engine = engine, CylinderCapacity = cc, MonthlyPrice = mp, Power = power }, "car");
            }
            else if (entity == "Renter")
            {
                Console.Write("Enter Renter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Renter Phone Number: ");
                string phoneNumber = Console.ReadLine();
                rest.Post(new Renter() { Name = name, PhoneNumber = phoneNumber }, "renter");
            }

        }
        static void List(string entity)
        {
            if (entity == "Company")
            {
                List<Company> companies = rest.Get<Company>("Company");
                foreach (var item in companies)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("Car");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Renter")
            {
                List<Renter> renters = rest.Get<Renter>("Renter");
                foreach (var item in renters)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.ReadLine();
        }
        static void ReadOne(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter Company's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Company one = rest.Get<Company>(id, "company");
                Console.WriteLine($"Name: {one.Name}\nEmail: {one.Email}\nPhone number: {one.PhoneNumber}");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter Car's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "car");
                Console.WriteLine($"Brand: {one.Brand}\nName: {one.Name}\nPower: {one.Power}");
            }
            else if(entity == "Renter")
            {
                Console.Write("Enter Renter's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Renter one = rest.Get<Renter>(id, "renter");
                Console.WriteLine($"Name: {one.Name}\nPhone number: {one.PhoneNumber}");
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter Company's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Company one = rest.Get<Company>(id, "company");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "company");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter Car's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "car");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "car");
            }
            else if (entity == "Renter")
            {
                Console.Write("Enter Renter's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Renter one = rest.Get<Renter>(id, "renter");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "renter");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Company")
            {
                Console.Write("Enter Company's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "company");
            }
            else if (entity == "Car")
            {
                Console.Write("Enter Car's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
            else if (entity == "Renter")
            {
                Console.Write("Enter Renter's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "renter");
            }
        }
        static void NonCrudMethods(string action)
        {
            if (action == "RichestRenter")
            {
                var result = rest.Get<KeyValuePair<string, int>>($"NonCrud/{action}");
                result.ToConsole("The Richest Renter");
            }
            else if (action == "MostPowerfulRentedCar")
            {
                var result = rest.Get<KeyValuePair<string, string>>($"NonCrud/{action}");
                result.ToConsole("Most Powerful Rented Car");
            }
            else if (action == "WhoPaysHigherThan4Grand")
            {
                var result = rest.Get<KeyValuePair<string, int>>($"NonCrud/{action}");
                result.ToConsole("They pay more than 4k monthly");
            }
            else if (action == "CompaniesWithRentedCars")
            {
                var result = rest.Get<KeyValuePair<string, int>>($"NonCrud/{action}");
                result.ToConsole("Companies With Rented Cars");
            }
            else if (action == "SupercarCompany")
            {
                var result = rest.Get<object>($"NonCrud/{action}");
                result.ToConsole("The Supercar Company (Owns the most powerful cars)");
                Console.ReadLine();
            }
            else if (action == "RentersWithSlowestCars")
            {
                var result = rest.Get<KeyValuePair<string, int>>($"NonCrud/{action}");
                result.ToConsole("The Renters With Slowest Weiders, with Power");
                Console.ReadLine();
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:11938/");

            var renterNonCrudSubMenu = new ConsoleMenu(args, level: 2)
                .Add("Richest Renter", () => NonCrudMethods("RichestRenter"))
                .Add("Who Pays Higher Than 4 Grand", () => NonCrudMethods("WhoPaysHigherThan4Grand"))
                .Add("Renters With Slowest Weiders", () => NonCrudMethods("RentersWithSlowestCars"))
                .Add("Exit", ConsoleMenu.Close);

            var carNonCrudSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Most Powerful Rented Car", () => NonCrudMethods("MostPowerfulRentedCar"))
               .Add("Exit", ConsoleMenu.Close);

            var companyNonCrudSubMenu = new ConsoleMenu(args, level: 2)
               .Add("Companies With Rented Cars", () => NonCrudMethods("CompaniesWithRentedCars"))
               .Add("Supercar Company", () => NonCrudMethods("SupercarCompany"))
               .Add("Exit", ConsoleMenu.Close);

            var companySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Company"))
                .Add("Read One", () => ReadOne("Company"))
                .Add("Create", () => Create("Company"))
                .Add("Delete", () => Delete("Company"))
                .Add("Update", () => Update("Company"))
                .Add("NonCrud", () => companyNonCrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Read One", () => ReadOne("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("NonCrud", () => carNonCrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var renterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Renter"))
                .Add("Read One", () => ReadOne("Renter"))
                .Add("Create", () => Create("Renter"))
                .Add("Delete", () => Delete("Renter"))
                .Add("Update", () => Update("Renter"))
                .Add("NonCrud", () => renterNonCrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Companies", () => companySubMenu.Show())
                .Add("Cars", () => carSubMenu.Show())
                .Add("Renter", () => renterSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
    //Test in ConsoleApp (add references)
    //class Program
    //{

    //    //static void Main(string[] args)
    //    //{
    //    //    #region log to console
    //    //    //cliensből kivenni repository reference-t (teszteléshez kell repository reference(kommentben van))
    //    //    //CarRenterDbContext ctx = new CarRenterDbContext();
    //    //    //var brand = ctx.Cars.FirstOrDefault(p => p.Power == 790);
    //    //    //var email = ctx.Companies.FirstOrDefault(p => p.Name == "ZoliAuto");
    //    //    //var renter = ctx.Renters.FirstOrDefault(p => p.Name == "Bérlo3");
    //    //    //var company1 = ctx.Companies.Where(p => p.Cars.Count() != 0);

    //    //    //Console.WriteLine("Name of the companies: ");
    //    //    //foreach (var item in ctx.Companies)
    //    //    //{
    //    //    //    Console.WriteLine(item.Name);
    //    //    //}
    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine("Cars in this company: ");
    //    //    //foreach (var item in company1)
    //    //    //{
    //    //    //    Console.WriteLine("Cég neve: [" + item.Name + "] autók száma: [" + item.Cars.Count + "]");

    //    //    //    foreach (var car in item.Cars)
    //    //    //    {
    //    //    //        Console.WriteLine("Cég autója: [" + car.Brand + " " + car.Name + "]");
    //    //    //        if (car.Renter != null)
    //    //    //        {
    //    //    //            Console.WriteLine("Bérloje: [" + car.Renter.Name + "]");
    //    //    //        }
    //    //    //        else
    //    //    //        {
    //    //    //            Console.WriteLine("Jelenleg nincs bérloje");
    //    //    //        }

    //    //    //        Console.WriteLine();
    //    //    //    }
    //    //    //    Console.WriteLine("-------------------");
    //    //    //}

    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine(renter.Car.Company.Name);


    //    //    //Console.WriteLine(brand.Company.Name);
    //    //    //Console.WriteLine(renter.Car.Name);

    //    //    //CarRepository carRepo = new CarRepository(ctx);
    //    //    //RenterRepository renterRepo = new RenterRepository(ctx);
    //    //    //CompanyRepository companyRepo = new CompanyRepository(ctx);

    //    //    //CarLogic carLogic = new CarLogic(carRepo);
    //    //    //RenterLogic renterLogic = new RenterLogic(renterRepo);
    //    //    //CompanyLogic companyLogic = new CompanyLogic(companyRepo);


    //    //    //Console.WriteLine("Kinek a bérletidíja kerül több, mint 4000-be?");
    //    //    //foreach (var item in renterLogic.WhoPaysHigherThan4Grand())
    //    //    //{
    //    //    //    Console.WriteLine(item);
    //    //    //}
    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine("Melyik vállalatnak hány autóját bérlik?");
    //    //    //foreach (var item in renterLogic.CompaniesWithRentedCars())
    //    //    //{
    //    //    //    Console.WriteLine(item);
    //    //    //}
    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine("Ki fizeti a legnagyobb bérletidíjat, és mennyit?");
    //    //    //var q3 = carLogic.RichestRenter();
    //    //    //foreach (var item in q3)
    //    //    //{
    //    //    //    Console.WriteLine(item);
    //    //    //}

    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine("Legnagyobb hengerűrtartalmú bérelt autó és bérlője:");
    //    //    //var q4 = carLogic.MostPowerfulRentedCar();
    //    //    //foreach (var item in q4)
    //    //    //{
    //    //    //    Console.WriteLine(item);
    //    //    //}

    //    //    //Console.WriteLine();
    //    //    //Console.WriteLine("Legerősebb autóflottával rendelkező vállalat és összteljesítménye");
    //    //    //var q5 = companyLogic.SupercarCompany();
    //    //    //foreach (var item in q5)
    //    //    //{
    //    //    //    Console.WriteLine($"Vállalat neve: {item.CompanyName} \nÖsszteljesítménye: {item.SumPower} lóerő");
    //    //    //}
    //    //    #endregion
    //    //}
    //}
}
