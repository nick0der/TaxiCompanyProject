using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public interface IDispatcherRepository
    {
        Task<IEnumerable<Dispatcher>> Get();
        Task<Dispatcher> Get(int id);
        Task<Dispatcher> Create(Dispatcher dispatcher);
        Task Update(Dispatcher dispatcher);
        Task Delete(int id);
    }
}