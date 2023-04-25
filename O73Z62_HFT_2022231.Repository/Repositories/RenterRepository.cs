using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Repository.Repositories
{
    public class RenterRepository : Repository<Renter>, IRenterRepository
    {
        public RenterRepository(CarRenterDbContext ctx) : base(ctx)
        {

        }
    }
}
