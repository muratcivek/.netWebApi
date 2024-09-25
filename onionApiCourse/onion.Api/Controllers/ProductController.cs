using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion.Application.Features.Product.Queries.GetAllProducts;
using onion.Application.Features.Products.Command.CreateProduct;
using onion.Application.Features.Products.Command.DeleteProduct;
using onion.Application.Features.Products.Command.UpdateProduct;

namespace onion.Api.Controllers
{
    [Route("api/[controller] /[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
           await mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
          await  mediator.Send(request);

            return Ok();
        }


    }
}