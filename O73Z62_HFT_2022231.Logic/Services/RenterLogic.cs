using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Logic.Services
{
    public class RenterLogic : IRenterLogic
    {
        IRenterRepository renterRepo;

        public RenterLogic(IRenterRepository renterRepo)
        {
            this.renterRepo = renterRepo;
        }

        public void Create(Renter renter)
        {
            if (renter.Name == null || renter.Name == "" || renter.PhoneNumber == null || renter.PhoneNumber == "")
            {
                throw new ArgumentNullException("You have to enter all the information");
            }
            else
            {
                renterRepo.Create(renter);
            }
        }

        public void Delete(int id)
        {
            renterRepo.Delete(id);
        }

        public Renter Read(int id)
        {
            Renter renter = renterRepo.Read(id);
            if(renter == null)
            {
                throw new ArgumentException($"Renter with id({id}) does not exists.");
            }
            return renter;
        }

        public IEnumerable<Renter> ReadAll()
        {
            return renterRepo.ReadAll();
        }

        public void Update(Renter renter)
        {
            renterRepo.Update(renter);
        }
        //Returns a KeyValuePair, which shows the people whose rent cost more than 4000
        //Uses the Renter and Car tables 
        public IEnumerable<KeyValuePair<string, int>> WhoPaysHigherThan4Grand()
        {
          
            return from x in renterRepo.ReadAll()
                   where x.Car.MonthlyPrice > 4000
                   select new KeyValuePair<string, int>(x.Name, x.Car.MonthlyPrice);
        }
        //Returns the amount of rented cars in each company
        //Uses the renter, the Car and the Company tables
        public IEnumerable<KeyValuePair<string, int>> CompaniesWithRentedCars()
        {
            return from x in renterRepo.ReadAll()
                   group x by x.Car.Company.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.Count());
        }
        //Returns the renters with the slowest cars
        public IEnumerable<KeyValuePair<string, int>> RentersWithSlowestCars()
        {
            return from x in renterRepo.ReadAll()
                   where x.Car.Power < 500
                   select new KeyValuePair<string, int>(x.Name, x.Car.Power);
        }

    }
}
