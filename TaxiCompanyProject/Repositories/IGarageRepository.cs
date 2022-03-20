using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface IGarageRepository
    {
        Task<IEnumerable<Garage>> Get();
        Task<Garage> Get(int id);
        Task<Garage> Create(Garage garage);
        Task Update(Garage garage);
        Task Delete(int id);
    }
}