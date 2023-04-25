using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Logic.Services
{
    public class CarLogic : ICarLogic
    {
        ICarRepository carRepo;

        public CarLogic(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }

        public void Create(Car car)
        {
            if (car.Brand == null || car.Power == 0 || car.Name == null || car.MonthlyPrice == 0 || car.CylinderCapacity == 0 || car.Engine == null
                || car.Brand == "" || car.Name == "" || car.Engine == "")
            {
                throw new ArgumentNullException("You have to enter all the information");
            }
            else
            {
                carRepo.Create(car);
            }
        }

        public void Delete(int id)
        {
            carRepo.Delete(id);
        }

        public Car Read(int id)
        {
            Car car = carRepo.Read(id);
            if (car == null)
            {
                throw new ArgumentException($"Car with id({id}) does not exists.");
            }
            return car;
        }

        public IEnumerable<Car> ReadAll()
        {
           return carRepo.ReadAll();
        }

        public void Update(Car car)
        {
            carRepo.Update(car);
        }

        //legdrágább bérletidíjat fizető autótulajdonos
        public IEnumerable<KeyValuePair<string, int>> RichestRenter()
        {
            var q = from x in carRepo.ReadAll()
                    where x.Renter.ID != null
                    orderby x.MonthlyPrice descending
                    select new KeyValuePair<string, int>(x.Renter.Name, x.MonthlyPrice);
            return q.Take(1);
        }
        //Legnagyobb hengerűrtartalmú autó bérlő és bérlője
        public IEnumerable<KeyValuePair<string, string>> MostPowerfulRentedCar()
        {
            var test = from x in carRepo.ReadAll()
                       where x.Renter.ID != null
                       orderby x.CylinderCapacity descending
                       select new KeyValuePair<string, string>(x.Renter.Name, $"{x.Brand} {x.Name} ({x.Engine})");
            return test.Take(1);
        }


    }
}
