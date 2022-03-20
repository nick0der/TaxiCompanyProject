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
    public class ChiefsController : ControllerBase
    {
        private readonly IAsyncRepository<Chief> _asyncRepository;

        public ChiefsController(IAsyncRepository<Chief> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Chief>> GetChiefs()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chief>> GetChiefs(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Chief>> PostChiefs([FromBody] ChiefDTO chiefDTO)
        {
            //Copy properties
            Chief chief = new Chief();
            chief.fullName = chiefDTO.fullName;
            chief.salary = chiefDTO.salary;
            chief.age = chiefDTO.age;
            chief.email = chiefDTO.email;
            chief.mobile = chiefDTO.mobile;
            chief.CreatedDate = DateTime.Now;
            chief.ModifiedDate = DateTime.Now;

            var newChief = await _asyncRepository.Create(chief);
            return CreatedAtAction(nameof(GetChiefs), new { id = newChief.Id }, newChief);
        }

        [HttpPut]
        public async Task<ActionResult> PutChiefs(int id, [FromBody] ChiefDTO chiefDTO)
        {
      
            Chief chief = await _asyncRepository.Get(id);

            chief.fullName = chiefDTO.fullName;
            chief.salary = chiefDTO.salary;
            chief.age = chiefDTO.age;
            chief.email = chiefDTO.email;
            chief.mobile = chiefDTO.mobile;
          
            chief.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(chief);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var chiefToDelete = await _asyncRepository.Get(id);
            if (chiefToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(chiefToDelete.Id);
            return NoContent();
        }

    }
}
