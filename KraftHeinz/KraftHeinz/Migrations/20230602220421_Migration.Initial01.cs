using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KraftHeinz.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitial01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerPlantId",
                table: "Reservoirs",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "PowerPlants",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerPlantId",
                table: "Reservoirs");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "PowerPlants");
        }
    }
}
