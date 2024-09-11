using OnionArchitecture.Application.Interfaces.Repository;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext): base(dbContext) { }
    }
}
