using Microsoft.EntityFrameworkCore;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Repository
{
    public partial class CarRenterDbContext : DbContext
    {
        
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Renter> Renters { get; set; }

        public CarRenterDbContext()
        {
            this.Database.EnsureCreated();
        }

        public CarRenterDbContext(DbContextOptions<CarRenterDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseInMemoryDatabase("CarRenterDb").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Renter>(entity =>
            {
                entity.HasOne(renter => renter.Car) // az bérlőnek van egy car navigation property -je
                    .WithOne(Car => Car.Renter)// egy autóhoz egy bérlő tartozik
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Company) // az autónak van egy Company navigation property -je
                    .WithMany(Company => Company.Cars) // egy companyhez tartozik több autó
                    .HasForeignKey(car => car.CompanyID) // milyen idegen kulcson keresztül kötöttük össze
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            Company company1 = new Company() { ID = 1, Name = "ZoliAutok", Email = "zoli@email.hu", PhoneNumber = "06301234566" };
            Company company2 = new Company() { ID = 2, Name = "PetiAutok", Email = "peti@email.hu", PhoneNumber = "06301234577" };
            Company company3 = new Company() { ID = 3, Name = "DavidAutok", Email = "david@email.hu", PhoneNumber = "06301234555" };
            Company company4 = new Company() { ID = 4, Name = "CsongiAutok", Email = "csongi@email.hu", PhoneNumber = "06301234533" };
            Company company5 = new Company() { ID = 5, Name = "RentCarAutok", Email = "rentcar@email.hu", PhoneNumber = "06301234522" };
            Car car1 = new Car() { ID = 1, CompanyID = company1.ID, Brand = "Ferrari", Name = "812 GTS", Engine = "V12", Power = 790, MonthlyPrice=10000, CylinderCapacity=6500 };
            Car car2 = new Car() { ID = 2, CompanyID = company1.ID, Brand = "mcLaren", Name = "720s", Engine = "V8", Power = 721, MonthlyPrice = 9500, CylinderCapacity = 4000 };
            Car car3 = new Car() { ID = 3, CompanyID = company2.ID, Brand = "BMW", Name = "M8 Gran Coupé", Engine = "V8", Power = 625, MonthlyPrice = 5000, CylinderCapacity = 4400 };
            Car car4 = new Car() { ID = 4, CompanyID = company2.ID, Brand = "BMW", Name = "M5 COmpetition", Engine = "V8 4,4L", Power = 625, MonthlyPrice = 4000, CylinderCapacity = 4400 };
            Car car5 = new Car() { ID = 5, CompanyID = company1.ID, Brand = "BMW", Name = "i8", Engine = "V8", Power = 400, MonthlyPrice = 1000, CylinderCapacity = 1500 };
            Car car6 = new Car() { ID = 6, CompanyID = company1.ID, Brand = "Audi", Name = "A4", Engine = "i4", Power = 145, MonthlyPrice = 700, CylinderCapacity = 2000 };
            Car car7 = new Car() { ID = 7, CompanyID = company2.ID, Brand = "Audi", Name = "Q8", Engine = "V6", Power = 432, MonthlyPrice = 1600, CylinderCapacity = 3000 };
            Car car8 = new Car() { ID = 8, CompanyID = company3.ID, Brand = "Audi", Name = "Q2", Engine = "V6", Power = 310, MonthlyPrice = 590, CylinderCapacity = 3000 };
            Car car9 = new Car() { ID = 9, CompanyID = company3.ID, Brand = "Audi", Name = "A8", Engine = "V6", Power = 480, MonthlyPrice = 1350, CylinderCapacity = 3000 };
            Car car10 = new Car() { ID = 10, CompanyID = company4.ID, Brand = "Audi", Name = "e-tron", Engine = "electric", Power = 300, MonthlyPrice = 2000, CylinderCapacity = 0 };
            Car car11 = new Car() { ID = 11, CompanyID = company4.ID, Brand = "Tesla", Name = "Model S", Engine = "electric", Power = 130, MonthlyPrice = 990, CylinderCapacity = 0 };
            Car car12 = new Car() { ID = 12, CompanyID = company5.ID, Brand = "Tesla", Name = "Model 3", Engine = "electric", Power = 290, MonthlyPrice = 1000, CylinderCapacity = 0 };
            Car car13 = new Car() { ID = 13, CompanyID = company5.ID, Brand = "Tesla", Name = "Model X", Engine = "electric", Power = 310, MonthlyPrice = 1100, CylinderCapacity = 0 };
            Car car14 = new Car() { ID = 14, CompanyID = company5.ID, Brand = "Ferrari", Name = "SF90", Engine = "hybrid", Power = 1000, MonthlyPrice = 1100, CylinderCapacity = 4000 };
            Car car15 = new Car() { ID = 15, CompanyID = company3.ID, Brand = "Ferrari", Name = "488", Engine = "V8", Power = 710, MonthlyPrice = 1100, CylinderCapacity = 4400 };
            Car car16 = new Car() { ID = 16, CompanyID = company5.ID, Brand = "Audi", Name = "Q8", Engine = "V6", Power = 625, MonthlyPrice = 1100, CylinderCapacity = 3000 };
            Renter renter1 = new Renter() { ID = 1, CarID = car1.ID, Name = "Bérlo1", PhoneNumber = "06301234568" };
            Renter renter2 = new Renter() { ID = 2, CarID = car2.ID, Name = "Bérlo2", PhoneNumber = "06301234510" };
            Renter renter3 = new Renter() { ID = 3, CarID = car3.ID, Name = "Bérlo3", PhoneNumber = "06301234580" };
            Renter renter4 = new Renter() { ID = 4, CarID = car4.ID, Name = "Bérlo4", PhoneNumber = "06301234533" };
            Renter renter5 = new Renter() { ID = 5, CarID = car7.ID, Name = "Bérlo5", PhoneNumber = "06301234534" };
            Renter renter6 = new Renter() { ID = 6, CarID = car10.ID, Name = "Bérlo6", PhoneNumber = "06301234599" };
            Renter renter7 = new Renter() { ID = 7, CarID = car11.ID, Name = "Bérlo7", PhoneNumber = "06301234500" };
            Renter renter8 = new Renter() { ID = 8, CarID = car16.ID, Name = "Bérlo8", PhoneNumber = "06301234561" };

            modelBuilder.Entity<Renter>().HasData(renter1, renter2, renter3, renter4, renter5, renter6, renter7, renter8); ;           
            modelBuilder.Entity<Car>().HasData(car1, car2, car3, car4, car5, car6, car7, car8, car9, car10, car11, car12, car13, car14, car15, car16);
            modelBuilder.Entity<Company>().HasData(company1, company2, company3, company4, company5);
            
        }


    }
}
