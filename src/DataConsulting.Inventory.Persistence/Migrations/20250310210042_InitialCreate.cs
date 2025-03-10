using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataConsulting.Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    base_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    caliber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    general_properties_is_imported = table.Column<bool>(type: "bit", nullable: true),
                    general_properties_has_drawback = table.Column<bool>(type: "bit", nullable: true),
                    general_properties_is_composite_product = table.Column<bool>(type: "bit", nullable: true),
                    logistics_properties_tracking_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logistics_properties_catalog_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adjustment_factors_weight_factor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    adjustment_factors_usage_factor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    adjustment_factors_conditioning_factor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    adjustment_factors_loss_factor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    physical_properties_weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    physical_properties_volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    expiration_has_expiration = table.Column<bool>(type: "bit", nullable: true),
                    expiration_duration_days = table.Column<int>(type: "int", nullable: true),
                    expiration_pre_expiration_days = table.Column<int>(type: "int", nullable: true),
                    taxation_foreign_vat = table.Column<bool>(type: "bit", nullable: true),
                    taxation_icbper_applicable = table.Column<bool>(type: "bit", nullable: true),
                    taxation_vat_applicable = table.Column<bool>(type: "bit", nullable: true),
                    taxation_vat_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    taxation_isc_applicable = table.Column<bool>(type: "bit", nullable: true),
                    taxation_isc_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    taxation_perception = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    taxation_withholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_products_user_id",
                table: "products",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
