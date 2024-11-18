using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsonCommerce.Application.Features;

namespace OsonCommerce.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/product_in_stock")]
    public class ProductInStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductInStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductInStock([FromBody] CreateProductInStockCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductInStockById([FromRoute] GetProductInStockByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductInStock([FromBody] UpdateProductInStockCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInStock([FromRoute] DeleteProductInStockCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductInStocks([FromQuery] GetAllProductInStocksQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        //todo: add getpaged method
    }
}
