using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace log_data_well.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WellMeasurements_WellMeasurementMeasurementID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WellMeasurementMeasurementID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WellMeasurementMeasurementID",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MeasurementID",
                table: "Orders",
                column: "MeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WellMeasurements_MeasurementID",
                table: "Orders",
                column: "MeasurementID",
                principalTable: "WellMeasurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WellMeasurements_MeasurementID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MeasurementID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "WellMeasurementMeasurementID",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WellMeasurementMeasurementID",
                table: "Orders",
                column: "WellMeasurementMeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WellMeasurements_WellMeasurementMeasurementID",
                table: "Orders",
                column: "WellMeasurementMeasurementID",
                principalTable: "WellMeasurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
