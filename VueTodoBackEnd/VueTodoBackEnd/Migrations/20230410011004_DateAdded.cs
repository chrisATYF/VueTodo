using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VueTodoBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class DateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TodoDate",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodoDate",
                table: "TodoItems");
        }
    }
}
