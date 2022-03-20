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
    public class TaxisController : ControllerBase
    {
        private readonly IAsyncRepository<Taxi> _asyncRepository;

        public TaxisController(IAsyncRepository<Taxi> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Taxi>> GetTaxis()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Taxi>> GetTaxis(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Taxi>> PostTaxis([FromBody] TaxiDTO taxiDTO)
        {
            //Copy properties
            Taxi taxi = new Taxi();

            taxi.color = taxiDTO.color;
            taxi.model = taxiDTO.model;
            taxi.seats = taxiDTO.seats;
            taxi.trackNumber = taxiDTO.trackNumber;
            taxi.Garage = taxiDTO.Garage;

            taxi.CreatedDate = DateTime.Now;
            taxi.ModifiedDate = DateTime.Now;

            var newTaxi = await _asyncRepository.Create(taxi);
            return CreatedAtAction(nameof(GetTaxis), new { id = newTaxi.Id }, newTaxi);
        }

        [HttpPut]
        public async Task<ActionResult> PutTaxis(int id, [FromBody] TaxiDTO taxiDTO)
        {

            Taxi taxi = await _asyncRepository.Get(id);

            taxi.color = taxiDTO.color;
            taxi.model = taxiDTO.model;
            taxi.seats = taxiDTO.seats;
            taxi.trackNumber = taxiDTO.trackNumber;
            taxi.Garage = taxiDTO.Garage;

            taxi.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(taxi);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var taxiToDelete = await _asyncRepository.Get(id);
            if (taxiToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(taxiToDelete.Id);
            return NoContent();
        }

    }
}
