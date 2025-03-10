using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intergalactic_Race_League.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverAge = table.Column<int>(type: "int", nullable: false),
                    DriverHeightInCm = table.Column<int>(type: "int", nullable: false),
                    DriverCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.RacerId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "RacerVehicles",
                columns: table => new
                {
                    RacerVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerVehicles", x => x.RacerVehicleId);
                    table.ForeignKey(
                        name: "FK_RacerVehicles_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "RacerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacerVehicles_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                    table.ForeignKey(
                        name: "FK_RacerVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    RacerOneID = table.Column<int>(type: "int", nullable: false),
                    RacerTwoId = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: false),
                    TournamentId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_Races_RacerVehicles_RacerOneID",
                        column: x => x.RacerOneID,
                        principalTable: "RacerVehicles",
                        principalColumn: "RacerVehicleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_RacerVehicles_RacerTwoId",
                        column: x => x.RacerTwoId,
                        principalTable: "RacerVehicles",
                        principalColumn: "RacerVehicleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_RacerVehicles_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "RacerVehicles",
                        principalColumn: "RacerVehicleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Races_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Races_Tournaments_TournamentId1",
                        column: x => x.TournamentId1,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacerVehicles_RacerId",
                table: "RacerVehicles",
                column: "RacerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RacerVehicles_TournamentId",
                table: "RacerVehicles",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_RacerVehicles_VehicleId",
                table: "RacerVehicles",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_RacerOneID",
                table: "Races",
                column: "RacerOneID");

            migrationBuilder.CreateIndex(
                name: "IX_Races_RacerTwoId",
                table: "Races",
                column: "RacerTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_TournamentId",
                table: "Races",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_TournamentId1",
                table: "Races",
                column: "TournamentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Races_WinnerId",
                table: "Races",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "RacerVehicles");

            migrationBuilder.DropTable(
                name: "Racers");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
