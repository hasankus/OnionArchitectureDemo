using OnionArchitecture.Domain.Common;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<Guid> UpdateAsync(T entity);
        Task<Guid> DeleteAsync(Guid id);
    }
}
