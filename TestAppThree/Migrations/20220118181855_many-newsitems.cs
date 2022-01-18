using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppThree.Migrations
{
    public partial class manynewsitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems",
                column: "CustomerId",
                unique: true);
        }
    }
}
