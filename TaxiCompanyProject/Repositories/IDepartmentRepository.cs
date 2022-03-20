using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> Get();
        Task<Department> Get(int id);
        Task<Department> Create(Department department);
        Task Update(Department department);
        Task Delete(int id);
    }
}