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
    public class DispatchersController : ControllerBase
    {
        private readonly IAsyncRepository<Dispatcher> _asyncRepository;

        public DispatchersController(IAsyncRepository<Dispatcher> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Dispatcher>> GetDispatchers()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dispatcher>> GetDispatchers(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Dispatcher>> PostDispatchers([FromBody] DispatcherDTO dispatcherDTO)
        {
            //Copy properties
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.fullName = dispatcherDTO.fullName;
            dispatcher.salary = dispatcherDTO.salary;
            dispatcher.age = dispatcherDTO.age;
            dispatcher.email = dispatcherDTO.email;
            dispatcher.mobile = dispatcherDTO.mobile;
            dispatcher.Department = dispatcherDTO.Department;

            dispatcher.CreatedDate = DateTime.Now;
            dispatcher.ModifiedDate = DateTime.Now;

            var newDispatcher = await _asyncRepository.Create(dispatcher);
            return CreatedAtAction(nameof(GetDispatchers), new { id = newDispatcher.Id }, newDispatcher);
        }

        [HttpPut]
        public async Task<ActionResult> PutDispatchers(int id, [FromBody] DispatcherDTO dispatcherDTO)
        {

            Dispatcher dispatcher = await _asyncRepository.Get(id);

            dispatcher.fullName = dispatcherDTO.fullName;
            dispatcher.salary = dispatcherDTO.salary;
            dispatcher.age = dispatcherDTO.age;
            dispatcher.email = dispatcherDTO.email;
            dispatcher.mobile = dispatcherDTO.mobile;
            dispatcher.Department = dispatcherDTO.Department;

            dispatcher.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(dispatcher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dispatcherToDelete = await _asyncRepository.Get(id);
            if (dispatcherToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(dispatcherToDelete.Id);
            return NoContent();
        }

    }
}
