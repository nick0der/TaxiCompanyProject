using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiCompanyProject.GenericAsyncRepository;
using Microsoft.AspNetCore.Mvc;
using TaxiCompanyProject.Models;
using TaxiCompanyProject.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxiCompanyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IAsyncRepository<Driver> _asyncRepository;

        public DriversController(IAsyncRepository<Driver> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDrivers(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> PostDrivers([FromBody] DriverDTO driverDTO)
        {
            //Copy properties
            Driver driver = new Driver();
            driver.fullName = driverDTO.fullName;
            driver.salary = driverDTO.salary;
            driver.age = driverDTO.age;
            driver.email = driverDTO.email;
            driver.mobile = driverDTO.mobile;
            driver.Taxi = driverDTO.Taxi;

            driver.CreatedDate = DateTime.Now;
            driver.ModifiedDate = DateTime.Now;

            var newDriver = await _asyncRepository.Create(driver);
            return CreatedAtAction(nameof(GetDrivers), new { id = newDriver.Id }, newDriver);
        }

        [HttpPut]
        public async Task<ActionResult> PutDrivers(int id, [FromBody] DriverDTO driverDTO)
        {

            Driver driver = await _asyncRepository.Get(id);

            driver.fullName = driverDTO.fullName;
            driver.salary = driverDTO.salary;
            driver.age = driverDTO.age;
            driver.email = driverDTO.email;
            driver.mobile = driverDTO.mobile;
            driver.Taxi = driverDTO.Taxi;

            driver.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(driver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var driverToDelete = await _asyncRepository.Get(id);
            if (driverToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(driverToDelete.Id);
            return NoContent();
        }

    }
}
