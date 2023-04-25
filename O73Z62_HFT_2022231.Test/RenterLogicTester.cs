using Moq;
using NUnit.Framework;
using O73Z62_HFT_2022231.Logic.Services;
using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Test
{
    [TestFixture]
    class RenterLogicTester
    {
        RenterLogic renterLogic;
        Mock<IRenterRepository> mockRenterRepo;
        [SetUp]
        public void Init()
        {
            var fakeCompany1 = new Company() { ID = 1, Name = "TesztVallalat1", Email = "abc", PhoneNumber = "111@gmail" };
            var fakeCompany2 = new Company() { ID = 2, Name = "TesztVallalat2", Email = "def", PhoneNumber = "222@gmail" };

            var car1 = new Car() { ID = 1, Company = fakeCompany2, Brand = "Ferrari", CylinderCapacity = 6500, Engine = "V12", MonthlyPrice = 10000, Name = "812 GTS", Power = 890 };
            var car2 = new Car() { ID = 2, Company = fakeCompany2, Brand = "mcLaren", CylinderCapacity = 4000, Engine = "V8", MonthlyPrice = 8000, Name = "765 LT", Power = 710 };
            var car3 = new Car() { ID = 3, Company = fakeCompany2, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 330 };
            var car4 = new Car() { ID = 4, Company = fakeCompany1, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 230 };

            var fakeRenter1 = new Renter() { ID = 1, Car = car1, Name = "Berlo1", PhoneNumber = "111" };
            var fakeRenter2 = new Renter() { ID = 2, Car = car2, Name = "Berlo2", PhoneNumber = "222" };
            var fakeRenter3 = new Renter() { ID = 3, Car = car3, Name = "Berlo3", PhoneNumber = "333" };
            var fakeRenter4 = new Renter() { ID = 4, Car = car4, Name = "Berlo4", PhoneNumber = "444" };

            var cars = new List<Car>() { car1, car2, car3, car4 };
            var renters = new List<Renter>() { fakeRenter1, fakeRenter2, fakeRenter3, fakeRenter4 };

            mockRenterRepo = new Mock<IRenterRepository>();
            mockRenterRepo
                .Setup(x => x.ReadAll())
                .Returns(renters.AsQueryable());

            renterLogic = new RenterLogic(mockRenterRepo.Object);
        }
        [Test]
        public void WhoPaysHigherThan4GrandTest()
        {
            var result = renterLogic.WhoPaysHigherThan4Grand().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Berlo1", 10000)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Berlo2", 8000)));
        }
        [Test]
        public void RentersWithSlowestCars()
        {
            var result = renterLogic.RentersWithSlowestCars().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Berlo3", 330)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("Berlo4", 230)));
        }
        [Test]
        public void CompaniesWithRentedCarsTest()
        {
            var result = renterLogic.CompaniesWithRentedCars().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("TesztVallalat2", 3)));
            Assert.That(result[1], Is.EqualTo(new KeyValuePair<string, int>("TesztVallalat1", 1)));
        }
        [Test]
        public void RenterReadTest()
        {
            
            Renter renter = new Renter()
            {
                Name = "David",
                PhoneNumber = "0630905162"
            };

            mockRenterRepo
                .Setup(r => r.Read(1))
                .Returns(renter);

            var result = renterLogic.Read(1);

            Assert.That(result, Is.EqualTo(renter));
        }
        [Test]
        public void CreateRenterInvalidTest()
        {
            Renter renter = new Renter()
            {
                //no name given
                //Name = "peter",
                PhoneNumber = "76512491"
            };

            Assert.Throws<ArgumentNullException>(
                () => renterLogic.Create(renter));
        }
        [Test]
        public void CreateRenterInvalidTest2()
        {
            Renter renter = new Renter()
            {
                //name = ""
                Name = "",
                PhoneNumber = "76512491"
            };

            Assert.Throws<ArgumentNullException>(
                () => renterLogic.Create(renter));
        }
    }
}
