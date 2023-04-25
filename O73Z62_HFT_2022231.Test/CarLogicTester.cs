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
    public class CarLogicTester
    {
        CarLogic carLogic;
        Mock<ICarRepository> mockCarRepo;

        [SetUp]
        public void Init()
        {
            var fakeCompany1 = new Company() { ID = 1, Name = "TesztVallalat1", Email = "abc", PhoneNumber = "111@gmail" };
            var fakeCompany2 = new Company() { ID = 2, Name = "TesztVallalat2", Email = "def", PhoneNumber = "222@gmail" };

            var fakeRenter1 = new Renter() { ID = 1, Name = "Berlo1", PhoneNumber = "111" };
            var fakeRenter2 = new Renter() { ID = 2, Name = "Berlo2", PhoneNumber = "222" };
            var fakeRenter3 = new Renter() { ID = 3, Name = "Berlo3", PhoneNumber = "333" };
            var fakeRenter4 = new Renter() { ID = 4, Name = "Berlo4", PhoneNumber = "444" };

            var car1 = new Car() { ID = 1, Renter = fakeRenter1, Brand = "Ferrari", CylinderCapacity = 6500, Engine = "V12", MonthlyPrice = 10000, Name = "812 GTS", Power = 890 };
            var car2 = new Car() { ID = 2, Renter = fakeRenter2, Brand = "mcLaren", CylinderCapacity = 4000, Engine = "V8", MonthlyPrice = 8000, Name = "765 LT", Power = 710 };
            var car3 = new Car() { ID = 3, Renter = fakeRenter3, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 330 };
            var car4 = new Car() { ID = 4, Renter = fakeRenter4, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 330 };

            var cars = new List<Car>() { car1, car2, car3, car4 };
            var renters = new List<Renter>() { fakeRenter1, fakeRenter2, fakeRenter3, fakeRenter4 };

            mockCarRepo = new Mock<ICarRepository>();
            mockCarRepo
                .Setup(x => x.ReadAll())
                .Returns(cars.AsQueryable());
            carLogic = new CarLogic(mockCarRepo.Object);
        }
        [Test]
        public void RichestRenterTest()
        {
            var result = carLogic.RichestRenter().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, int>("Berlo1", 10000)));
        }
        [Test]
        public void MostPowerfulRentedCarTest()
        {
            var result = carLogic.MostPowerfulRentedCar().ToArray();
            Assert.That(result[0], Is.EqualTo(new KeyValuePair<string, string>("Berlo1", "Ferrari 812 GTS (V12)")));
        }
        [Test]
        public void DeleteTest()
        {
            carLogic.Delete(1);
            mockCarRepo.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void ReadWithInvalidIdTest()
        {
            mockCarRepo
                .Setup(r => r.Read(It.IsAny<int>()))
                .Returns(value: null);
            Assert.Throws<ArgumentException>(
                () => carLogic.Read(1));
        }
        [Test]
        public void CreateCarInvalidTest()
        {
            Car car = new Car()
            {
                Name = "Name",
                Brand = "Brand",
                MonthlyPrice = 10,
                Engine = "v12",
                CylinderCapacity = 2000,
                //without power
                //Power = 1000
            };

            Assert.Throws<ArgumentNullException>(
                () => carLogic.Create(car));
        }
        [Test]
        public void CreateCarInvalidTest2()
        {
            Car car = new Car()
            {
                //input = ""
                Name = "",
                Brand = "01",
                MonthlyPrice = 10,
                Engine = "v12",
                CylinderCapacity = 2000,
                Power = 1000
            };

            Assert.Throws<ArgumentNullException>(
                () => carLogic.Create(car));
        }
    }
}
