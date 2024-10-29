using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mickion.tuckshops.warehouse.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrationsTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Product",
                table: "tblProducts");

            migrationBuilder.DropIndex(
                name: "IX_tblProducts_MeasurementsId",
                table: "tblProducts");

            migrationBuilder.DropColumn(
                name: "MeasurementsId",
                table: "tblProducts");

            migrationBuilder.CreateTable(
                name: "MeasurementProduct",
                columns: table => new
                {
                    MeasurementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementProduct", x => new { x.MeasurementsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_MeasurementProduct_tblMeasurements_MeasurementsId",
                        column: x => x.MeasurementsId,
                        principalTable: "tblMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementProduct_tblProducts_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementProduct_ProductsId",
                table: "MeasurementProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "MeasurementsId",
                table: "tblProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_MeasurementsId",
                table: "tblProducts",
                column: "MeasurementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Product",
                table: "tblProducts",
                column: "MeasurementsId",
                principalTable: "tblMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
