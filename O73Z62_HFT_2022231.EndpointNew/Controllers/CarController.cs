using Microsoft.AspNetCore.Mvc;
using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace O73Z62_HFT_2022231.EndpointNew.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic logic;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Car value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
