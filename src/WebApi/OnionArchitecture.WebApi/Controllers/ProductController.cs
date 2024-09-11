using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Dto;
using OnionArchitecture.Application.Features.Commands.CreateProduct;
using OnionArchitecture.Application.Features.Commands.DeleteProduct;
using OnionArchitecture.Application.Features.Commands.UpdateProduct;
using OnionArchitecture.Application.Features.Queries.GetAllProducts;
using OnionArchitecture.Application.Features.Queries.GetProductById;
using OnionArchitecture.Application.Interfaces.Repository;

namespace OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery()
            {
                Id = id
            };

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand()
            {
                Id = id
            };

            return Ok(await mediator.Send(command));
        }
    }
}
