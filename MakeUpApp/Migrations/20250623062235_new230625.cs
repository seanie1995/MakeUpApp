using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeUpApp.Migrations
{
    /// <inheritdoc />
    public partial class new230625 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeid",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeid",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeid",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductTypes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "ProductTypeid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeid",
                table: "Products",
                column: "ProductTypeid",
                principalTable: "ProductTypes",
                principalColumn: "id");
        }
    }
}
