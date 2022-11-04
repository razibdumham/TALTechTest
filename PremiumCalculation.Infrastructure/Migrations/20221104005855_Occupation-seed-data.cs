using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumCalculation.Infrastructure.Migrations
{
    public partial class Occupationseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupations_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Factor", "RatingTitle" },
                values: new object[,]
                {
                    { 1, 1m, "Professional" },
                    { 2, 1.25m, "White Collar" },
                    { 3, 1.50m, "Light Manual" },
                    { 4, 1.75m, "Heavy Manual" }
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "OccupationTitle", "RatingId" },
                values: new object[,]
                {
                    { 2, "Doctor", 1 },
                    { 3, "Author", 2 },
                    { 1, "Cleaner", 3 },
                    { 6, "Florist", 3 },
                    { 4, "Farmer", 4 },
                    { 5, "Mechanic", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_RatingId",
                table: "Occupations",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
