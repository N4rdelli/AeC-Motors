using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ModelsFinalizadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumer",
                columns: table => new
                {
                    CostumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostumerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CostumerCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CostumerRG = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CostumerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CostumerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumer", x => x.CostumerId);
                });

            migrationBuilder.CreateTable(
                name: "Yard",
                columns: table => new
                {
                    YardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YardAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YardTotalCapacity = table.Column<int>(type: "int", nullable: false),
                    YardCurrentQuantity = table.Column<int>(type: "int", nullable: false),
                    YardCurrentColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yard", x => x.YardId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    YardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleStatus = table.Column<bool>(type: "bit", nullable: false),
                    VehicleRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_Yard_YardId",
                        column: x => x.YardId,
                        principalTable: "Yard",
                        principalColumn: "YardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalStart = table.Column<DateOnly>(type: "date", nullable: false),
                    RentalEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    RentalPrince = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RentalPaymentStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Costumer_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumer",
                        principalColumn: "CostumerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CostumerId",
                table: "Rental",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_VehicleId",
                table: "Rental",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_YardId",
                table: "Vehicle",
                column: "YardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Costumer");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Yard");
        }
    }
}
