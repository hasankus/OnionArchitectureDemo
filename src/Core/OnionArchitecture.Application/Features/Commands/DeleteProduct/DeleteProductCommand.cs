using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Interfaces.Repository;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                await productRepository.DeleteAsync(product.Id);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
