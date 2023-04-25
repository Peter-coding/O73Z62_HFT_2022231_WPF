using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Logic.Interfaces
{
    public interface ICarLogic
    {
        void Create(Car car);
        void Delete(int id);
        IEnumerable<Car> ReadAll();
        Car Read(int id);
        void Update(Car car);
        IEnumerable<KeyValuePair<string, int>> RichestRenter();
        IEnumerable<KeyValuePair<string, string>> MostPowerfulRentedCar();

    }
}
