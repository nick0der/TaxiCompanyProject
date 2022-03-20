using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface IChiefRepository
    {
        Task<IEnumerable<Chief>> Get();
        Task<Chief> Get(int id);
        Task<Chief> Create(Chief chief);
        Task Update(Chief chief);
        Task Delete(int id);
    }
}