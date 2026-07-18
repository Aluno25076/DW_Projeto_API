using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserNameMyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AppUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AppUsers");
        }
    }
}
