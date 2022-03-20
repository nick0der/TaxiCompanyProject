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
    public class DepartmentsController : ControllerBase
    {
        private readonly IAsyncRepository<Department> _asyncRepository;

        public DepartmentsController(IAsyncRepository<Department> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _asyncRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartments(int id)
        {
            return await _asyncRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartments([FromBody] DepartmentDTO departmentDTO)
        {
            //Copy properties
            Department department = new Department();
            department.address = departmentDTO.address;
            department.Chief = departmentDTO.Chief;

            department.CreatedDate = DateTime.Now;
            department.ModifiedDate = DateTime.Now;

            var newDepartment = await _asyncRepository.Create(department);
            return CreatedAtAction(nameof(GetDepartments), new { id = newDepartment.Id }, newDepartment);
        }

        [HttpPut]
        public async Task<ActionResult> PutDepartments(int id, [FromBody] DepartmentDTO departmentDTO)
        {

            Department department = await _asyncRepository.Get(id);

            department.address = departmentDTO.address;
            department.Chief = departmentDTO.Chief;

            department.ModifiedDate = DateTime.Now;

            await _asyncRepository.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var departmentToDelete = await _asyncRepository.Get(id);
            if (departmentToDelete == null)
            {
                return NotFound();
            }


            await _asyncRepository.Delete(departmentToDelete.Id);
            return NoContent();
        }

    }
}
