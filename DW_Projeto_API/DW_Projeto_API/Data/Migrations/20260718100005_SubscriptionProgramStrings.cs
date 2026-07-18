using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionProgramStrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "AppUsers",
                newName: "MemberNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberNumber",
                table: "AppUsers",
                newName: "MemberId");
        }
    }
}
