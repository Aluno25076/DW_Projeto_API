using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationToSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Subscriptions");
        }
    }
}
