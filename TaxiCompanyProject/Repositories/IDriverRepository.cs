using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> Get();
        Task<Driver> Get(int id);
        Task<Driver> Create(Driver driver);
        Task Update(Driver driver);
        Task Delete(int id);
    }
}