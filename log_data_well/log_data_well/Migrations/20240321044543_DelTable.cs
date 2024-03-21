using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace log_data_well.Migrations
{
    public partial class DelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WellMeasurements_MeasurementTypes_MeasurementTypeID",
                table: "WellMeasurements");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");

            migrationBuilder.DropIndex(
                name: "IX_WellMeasurements_MeasurementTypeID",
                table: "WellMeasurements");

            migrationBuilder.DropColumn(
                name: "MeasurementTypeID",
                table: "WellMeasurements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasurementTypeID",
                table: "WellMeasurements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                columns: table => new
                {
                    MeasurementTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MeasurementUnits = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.MeasurementTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WellMeasurements_MeasurementTypeID",
                table: "WellMeasurements",
                column: "MeasurementTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WellMeasurements_MeasurementTypes_MeasurementTypeID",
                table: "WellMeasurements",
                column: "MeasurementTypeID",
                principalTable: "MeasurementTypes",
                principalColumn: "MeasurementTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
