using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface ITaxiRepository
    {
        Task<IEnumerable<Taxi>> Get();
        Task<Taxi> Get(int id);
        Task<Taxi> Create(Taxi taxi);
        Task Update(Taxi taxi);
        Task Delete(int id);
    }
}