using DataConsulting.Inventory.Application.Products.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataConsulting.Inventory.API.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SearchProducts(
        Guid id,
        CancellationToken cancellationToken
    )
        {
            var query = new GetProductQuery(id);
            var resultados = await _sender.Send(query, cancellationToken);

            return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
        }
    }
}
