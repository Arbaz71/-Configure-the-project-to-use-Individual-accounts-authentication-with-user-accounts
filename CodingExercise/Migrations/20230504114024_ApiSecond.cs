using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingExercise.Migrations
{
    /// <inheritdoc />
    public partial class ApiSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserManager",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserManager");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserManager",
                newName: "UserName");
        }
    }
}
