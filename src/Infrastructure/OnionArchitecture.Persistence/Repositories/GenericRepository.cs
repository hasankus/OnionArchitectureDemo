using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Interfaces.Repository;
using OnionArchitecture.Domain.Common;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var product = await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                dbContext.Set<T>().Remove(product);
            }

            await dbContext.SaveChangesAsync();
            return id;
        }

        public async Task<Guid> UpdateAsync(T entity)
        {
            var product = await dbContext.Set<T>().FindAsync(entity.Id);
            dbContext.Entry(product).CurrentValues.SetValues(entity);

            await dbContext.SaveChangesAsync();

            return entity.Id;
        }
    }
}
