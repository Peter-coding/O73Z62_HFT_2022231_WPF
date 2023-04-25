using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Logic.Interfaces
{
    public interface IRenterLogic
    {
        void Create(Renter renter);
        void Delete(int id);
        IEnumerable<Renter> ReadAll();
        Renter Read(int id);
        void Update(Renter renter);
        IEnumerable<KeyValuePair<string, int>> WhoPaysHigherThan4Grand();
        IEnumerable<KeyValuePair<string, int>> CompaniesWithRentedCars();
        IEnumerable<KeyValuePair<string, int>> RentersWithSlowestCars();
    }
}
