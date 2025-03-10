using Bogus;
using Dapper;
using DataConsulting.Inventory.Application.Abstractions.Data;

namespace DataConsulting.Inventory.API.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> products = new();

            for (var i = 0; i < 10; i++) // Generará 10 registros de prueba
            {
                products.Add(new
                {
                    id = Guid.NewGuid(),
                    user_id = Guid.Parse("3A2E684B-D9F6-4020-8D06-228FE7B32DA1"), // Asigna un user_id aleatorio (ajústalo si necesitas un usuario real)
                    code = faker.Random.AlphaNumeric(10),
                    name = faker.Commerce.ProductName(),
                    description = faker.Lorem.Sentence(),
                    base_unit = faker.Commerce.ProductMaterial(), // Cambiado de Unit() a ProductMaterial()
                    product_type = faker.Commerce.Department(),
                    category = faker.Commerce.Categories(1).First(),
                    caliber = faker.Random.Word(),
                    is_active = faker.Random.Bool(),
                    general_properties_is_imported = faker.Random.Bool(),
                    general_properties_has_drawback = faker.Random.Bool(),
                    general_properties_is_composite_product = faker.Random.Bool(),
                    logistics_properties_tracking_type = faker.Random.Word(),
                    logistics_properties_catalog_type = faker.Random.Word(),
                    adjustment_factors_weight_factor = faker.Random.Decimal(1, 10),
                    adjustment_factors_usage_factor = faker.Random.Decimal(1, 10),
                    adjustment_factors_conditioning_factor = faker.Random.Decimal(1, 10),
                    adjustment_factors_loss_factor = faker.Random.Decimal(0, 5),
                    physical_properties_weight = faker.Random.Decimal(1, 100),
                    physical_properties_volume = faker.Random.Decimal(1, 100),
                    expiration_has_expiration = faker.Random.Bool(),
                    expiration_duration_days = faker.Random.Int(1, 365),
                    expiration_pre_expiration_days = faker.Random.Int(1, 30),
                    taxation_foreign_vat = faker.Random.Bool(),
                    taxation_icbper_applicable = faker.Random.Bool(),
                    taxation_vat_applicable = faker.Random.Bool(),
                    taxation_vat_percentage = faker.Random.Decimal(0, 18),
                    taxation_isc_applicable = faker.Random.Bool(),
                    taxation_isc_percentage = faker.Random.Decimal(0, 10),
                    taxation_perception = faker.Random.Decimal(0, 5),
                    taxation_withholding = faker.Random.Decimal(0, 5),
                    version = faker.Random.Long(1, 100)
                });
            }

            const string sql = """
                INSERT INTO products
                    (id, user_id, code, name, description, base_unit, product_type, category, caliber, is_active,
                     general_properties_is_imported, general_properties_has_drawback, general_properties_is_composite_product,
                     logistics_properties_tracking_type, logistics_properties_catalog_type, adjustment_factors_weight_factor,
                     adjustment_factors_usage_factor, adjustment_factors_conditioning_factor, adjustment_factors_loss_factor,
                     physical_properties_weight, physical_properties_volume, expiration_has_expiration, expiration_duration_days,
                     expiration_pre_expiration_days, taxation_foreign_vat, taxation_icbper_applicable, taxation_vat_applicable,
                     taxation_vat_percentage, taxation_isc_applicable, taxation_isc_percentage, taxation_perception,
                     taxation_withholding, version)
                VALUES
                    (@id, @user_id, @code, @name, @description, @base_unit, @product_type, @category, @caliber, @is_active,
                     @general_properties_is_imported, @general_properties_has_drawback, @general_properties_is_composite_product,
                     @logistics_properties_tracking_type, @logistics_properties_catalog_type, @adjustment_factors_weight_factor,
                     @adjustment_factors_usage_factor, @adjustment_factors_conditioning_factor, @adjustment_factors_loss_factor,
                     @physical_properties_weight, @physical_properties_volume, @expiration_has_expiration, @expiration_duration_days,
                     @expiration_pre_expiration_days, @taxation_foreign_vat, @taxation_icbper_applicable, @taxation_vat_applicable,
                     @taxation_vat_percentage, @taxation_isc_applicable, @taxation_isc_percentage, @taxation_perception,
                     @taxation_withholding, @version)
                """;

            connection.Execute(sql, products);
        }
    }
}
