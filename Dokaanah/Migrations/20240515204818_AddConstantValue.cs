using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dokaanah.Migrations
{
    /// <inheritdoc />
    public partial class AddConstantValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberConstant",
                table: "Cart_Products",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberConstant",
                table: "Cart_Products");
        }
    }
}
