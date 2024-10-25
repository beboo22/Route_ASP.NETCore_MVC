using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkDev._1stproj.DAL.Presistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class imagecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Employees");
        }
    }
}
