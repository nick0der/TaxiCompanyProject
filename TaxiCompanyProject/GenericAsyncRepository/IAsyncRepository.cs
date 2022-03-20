using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.GenericAsyncRepository
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);

    }
}