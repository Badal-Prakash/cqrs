using Application.Features.Product.Command;
using Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public ProductsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct, CancellationToken cancellationToken)
        {
            var res = await _mediatR.Send(createProduct, cancellationToken);
            return Ok(res);
        }
        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct, CancellationToken cancellationToken)
        {
            var res = await _mediatR.Send(updateProduct, cancellationToken);
            return Ok(res);
        }
        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> deleteProduct(int id, CancellationToken cancellationToken)
        {
            var res = await _mediatR.Send(new DeleteProductCommand { Id = id }, cancellationToken);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var res = await _mediatR.Send(new GetAllProductQuery());
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var res = await _mediatR.Send(new GetProductByIdQuery { Id = id });
            return Ok(res);
        }


    }
}
