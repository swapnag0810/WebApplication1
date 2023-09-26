using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modifiedDate",
                table: "Products",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Products",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Products",
                newName: "modifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "createdDate");
        }
    }
}
