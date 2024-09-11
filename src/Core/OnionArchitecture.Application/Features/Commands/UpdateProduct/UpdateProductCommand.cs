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

namespace OnionArchitecture.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                await productRepository.UpdateAsync(product);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
