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
using static O73Z62_HFT_2022231.Logic.Services.CompanyLogic;

namespace O73Z62_HFT_2022231.Test
{
    [TestFixture]
    class CompanyLogicTester
    {
        CompanyLogic companyLogic;
        Mock<ICompanyRepository> mockCompanyRepo;
        [SetUp]
        public void Init()
        {
            var car1 = new Car() {ID = 1, Brand = "Ferrari", CylinderCapacity = 6500, Engine = "V12", MonthlyPrice = 10000, Name = "812 GTS", Power = 1000 };
            var car2 = new Car() { ID = 2, Brand = "mcLaren", CylinderCapacity = 4000, Engine = "V8", MonthlyPrice = 8000, Name = "765 LT", Power = 1000 };
            var car3 = new Car() { ID = 4, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 1000 };
            var car4 = new Car() { ID = 4, Brand = "BMW", CylinderCapacity = 2500, Engine = "V6", MonthlyPrice = 2000, Name = "E36", Power = 330 };

            var cars1 = new List<Car>() { car1, car2, car3 };
            var cars2 = new List<Car>() { car4};

            var fakeCompany1 = new Company() { ID = 1, Cars = cars1, Name = "TesztVallalat1", Email = "abc", PhoneNumber = "111@gmail" };
            var fakeCompany2 = new Company() { ID = 2, Cars = cars2, Name = "TesztVallalat2", Email = "def", PhoneNumber = "222@gmail" };

            mockCompanyRepo = new Mock<ICompanyRepository>();
            mockCompanyRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Company>
                {fakeCompany1, fakeCompany2}.AsQueryable());

            companyLogic = new CompanyLogic(mockCompanyRepo.Object);

        }
        [Test]
        public void SupercarCompanyTest()
        {
            var result = companyLogic.SupercarCompany().ToList();
            var resultObj = new Supercar() { CompanyName = "TesztVallalat1", SumPower = 3000 };
            Assert.AreEqual(result[0], resultObj);
        }
        [Test]
        public void CreateCompanyInvalidTest()
        {
            Company company = new Company()
            {
                Name = null,
                PhoneNumber = "76512491",
                Email = "asd@gmail.com"
            };

            Assert.Throws<ArgumentNullException>(
                () => companyLogic.Create(company));
        }
        [Test]
        public void CreateCompanyInvalidTest2()
        {
            Company company = new Company()
            {
                Name = "",
                PhoneNumber = "76512491",
                Email = "asd@gmail.com"
            };

            Assert.Throws<ArgumentNullException>(
                () => companyLogic.Create(company));
        }
    }
}
