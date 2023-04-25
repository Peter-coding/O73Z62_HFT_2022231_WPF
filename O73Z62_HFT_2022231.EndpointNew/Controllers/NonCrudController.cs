using Microsoft.AspNetCore.Mvc;
using O73Z62_HFT_2022231.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static O73Z62_HFT_2022231.Logic.Services.CompanyLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O73Z62_HFT_2022231.EndpointNew.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ICompanyLogic companyLogic;
        ICarLogic carLogic;
        IRenterLogic renterLogic;

        public NonCrudController(ICompanyLogic companyLogic, ICarLogic carLogic, IRenterLogic renterLogic)
        {
            this.companyLogic = companyLogic;
            this.carLogic = carLogic;
            this.renterLogic = renterLogic;
        }

        [HttpGet]
        public IEnumerable<Supercar> SupercarCompany()
        {
            return this.companyLogic.SupercarCompany();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> RichestRenter()
        {
            return this.carLogic.RichestRenter();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> MostPowerfulRentedCar()
        {
            return this.carLogic.MostPowerfulRentedCar();

        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> WhoPaysHigherThan4Grand()
        {
            return this.renterLogic.WhoPaysHigherThan4Grand();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CompaniesWithRentedCars()
        {
            return this.renterLogic.CompaniesWithRentedCars();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> RentersWithSlowestCars()
        {
            return this.renterLogic.RentersWithSlowestCars();
        }
    }
}
