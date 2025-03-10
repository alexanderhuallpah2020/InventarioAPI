using Dapper;
using DataConsulting.Inventory.Application.Abstractions.Data;
using DataConsulting.Inventory.Application.Abstractions.Messaging;
using DataConsulting.Inventory.Domain.Primitives;

namespace DataConsulting.Inventory.Application.Products.GetProduct
{
    internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetProductQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
               SELECT
                    id AS Id,
                    user_id AS UserId,
                    code AS Code,
                    name AS Name,
                    description AS Description

               FROM products WHERE id=@ProductId  
            """;

            var product = await connection.QueryFirstOrDefaultAsync<ProductResponse>(
                sql,
                new
                {
                    request.ProductId
                }
            );
            return product!;
        }
    }
}
