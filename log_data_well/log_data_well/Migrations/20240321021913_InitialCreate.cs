using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace log_data_well.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                columns: table => new
                {
                    MeasurementTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MeasurementUnits = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.MeasurementTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationID);
                });

            migrationBuilder.CreateTable(
                name: "WellTypes",
                columns: table => new
                {
                    WellTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellTypes", x => x.WellTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    SpecialistID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    AccountStatus = table.Column<string>(type: "TEXT", nullable: false),
                    SpecializationID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.SpecialistID);
                    table.ForeignKey(
                        name: "FK_Specialists_Specializations_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wells",
                columns: table => new
                {
                    WellID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WellTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    GeoCoordinates = table.Column<string>(type: "TEXT", nullable: false),
                    Depth = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wells", x => x.WellID);
                    table.ForeignKey(
                        name: "FK_Wells_WellTypes_WellTypeID",
                        column: x => x.WellTypeID,
                        principalTable: "WellTypes",
                        principalColumn: "WellTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WellMeasurements",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WellID = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementValue = table.Column<double>(type: "REAL", nullable: false),
                    MeasurementDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellMeasurements", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_WellMeasurements_MeasurementTypes_MeasurementTypeID",
                        column: x => x.MeasurementTypeID,
                        principalTable: "MeasurementTypes",
                        principalColumn: "MeasurementTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WellMeasurements_Wells_WellID",
                        column: x => x.WellID,
                        principalTable: "Wells",
                        principalColumn: "WellID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialistID = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementID = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderStatus = table.Column<string>(type: "TEXT", nullable: false),
                    WellMeasurementMeasurementID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Specialists_SpecialistID",
                        column: x => x.SpecialistID,
                        principalTable: "Specialists",
                        principalColumn: "SpecialistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_WellMeasurements_WellMeasurementMeasurementID",
                        column: x => x.WellMeasurementMeasurementID,
                        principalTable: "WellMeasurements",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SpecialistID",
                table: "Orders",
                column: "SpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WellMeasurementMeasurementID",
                table: "Orders",
                column: "WellMeasurementMeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_SpecializationID",
                table: "Specialists",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_WellMeasurements_MeasurementTypeID",
                table: "WellMeasurements",
                column: "MeasurementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_WellMeasurements_WellID",
                table: "WellMeasurements",
                column: "WellID");

            migrationBuilder.CreateIndex(
                name: "IX_Wells_WellTypeID",
                table: "Wells",
                column: "WellTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "WellMeasurements");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");

            migrationBuilder.DropTable(
                name: "Wells");

            migrationBuilder.DropTable(
                name: "WellTypes");
        }
    }
}
