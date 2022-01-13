using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppThree.Migrations
{
    public partial class addedcustomertonews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "NewsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_Customer_CustomerId",
                table: "NewsItems",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_Customer_CustomerId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CustomerId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "NewsItems");
        }
    }
}
