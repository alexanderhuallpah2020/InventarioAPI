using DataConsulting.Inventory.Application.Products.CreateProduct;
using DataConsulting.Inventory.Application.Products.GetProduct;
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
            // 🛠️ Crear los Value Objects correctamente
            var generalProperties = new GeneralProperties(
                request.GeneralProperties.IsImported,
                request.GeneralProperties.HasDrawback,
                request.GeneralProperties.IsCompositeProduct
            );

            var logisticsProperties = new LogisticsProperties(
                request.LogisticsProperties.TrackingType,
                request.LogisticsProperties.CatalogType
            );

            var adjustmentFactors = new AdjustmentFactors(
                request.AdjustmentFactors.WeightFactor,
                request.AdjustmentFactors.UsageFactor,
                request.AdjustmentFactors.ConditioningFactor,
                request.AdjustmentFactors.LossFactor
            );

            var physicalProperties = new PhysicalProperties(
                request.PhysicalProperties.Weight,
                request.PhysicalProperties.Volume
            );

            var expiration = new Expiration(
                request.Expiration.HasExpiration,
                request.Expiration.DurationDays,
                request.Expiration.PreExpirationDays
            );

            var taxation = new Taxation(
                request.Taxation.ForeignVAT,
                request.Taxation.ICBPERApplicable,
                request.Taxation.VATApplicable,
                request.Taxation.VATPercentage,
                request.Taxation.ISCApplicable,
                request.Taxation.ISCPercentage,
                request.Taxation.Perception,
                request.Taxation.Withholding
            );

            // 📌 Pasamos los Value Objects en lugar de valores individuales
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
                generalProperties,     // ✅ Pasamos los objetos ValueObject
                logisticsProperties,
                adjustmentFactors,
                physicalProperties,
                expiration,
                taxation
            );


            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return Unauthorized(result.Error);
            }

            return Ok(result.Value);
        }
    }
}
