using Microsoft.AspNetCore.Mvc;
using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O73Z62_HFT_2022231.EndpointNew.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        IRenterLogic logic;

        public RenterController(IRenterLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Renter> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Renter Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Renter value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Renter value)
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
