using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Repository.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRenterDbContext ctx) : base(ctx)
        {

        }
    }
}
