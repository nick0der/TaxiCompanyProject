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
    public class GaragesController : ControllerBase
    {
        private readonly IAsyncRepository<Garage> _asyncRepository;

        public GaragesController(IAsyncRepository<Garage> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Garage>> GetGarages()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarages(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarages([FromBody] GarageDTO garageDTO)
        {
            //Copy properties
            Garage garage = new Garage();

            garage.number = garageDTO.number;
            garage.area = garageDTO.area;
            garage.Department = garageDTO.Department;

            garage.CreatedDate = DateTime.Now;
            garage.ModifiedDate = DateTime.Now;

            var newGarage = await _asyncRepository.Create(garage);
            return CreatedAtAction(nameof(GetGarages), new { id = newGarage.Id }, newGarage);
        }

        [HttpPut]
        public async Task<ActionResult> PutGarages(int id, [FromBody] GarageDTO garageDTO)
        {

            Garage garage = await _asyncRepository.Get(id);

            garage.number = garageDTO.number;
            garage.area = garageDTO.area;
            garage.Department = garageDTO.Department;

            garage.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(garage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var garageToDelete = await _asyncRepository.Get(id);
            if (garageToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(garageToDelete.Id);
            return NoContent();
        }

    }
}
