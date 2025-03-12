using DataConsulting.Inventory.Application.Products.CreateProduct;
using DataConsulting.Inventory.Application.Products.GetProduct;
using DataConsulting.Inventory.Application.Products.UpdateProduct;
using DataConsulting.Inventory.Domain.Products.ValueObjects;
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
        CancellationToken cancellationToken)
        {
            var query = new GetProductQuery(id);
            var resultados = await _sender.Send(query, cancellationToken);

            return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
        }





        [HttpPost("register")]
        public async Task<IActionResult> CreateProducts(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(
                request.UserId,
                request.Code,
                request.Name,
                request.Description,
                request.BaseUnit,
                request.ProductType,
                request.Category,
                request.Caliber,
                request.IsActive,
                request.GeneralProperties,
                request.LogisticsProperties,
                request.AdjustmentFactors,
                request.PhysicalProperties,
                request.Expiration,
                request.Taxation
            );


            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(
            Guid id,
            [FromBody] UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest("El ID en la URL no coincide con el del cuerpo de la solicitud.");


            var command = new UpdateProductCommand(
                request.Id,
                request.UserId,
                request.Code,
                request.Name,
                request.Description,
                request.BaseUnit,
                request.ProductType,
                request.Category,
                request.Caliber,
                request.IsActive,
                request.GeneralProperties,
                request.LogisticsProperties,
                request.AdjustmentFactors,
                request.PhysicalProperties,
                request.Expiration,
                request.Taxation
            );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result.Value);
        }

    }
}
