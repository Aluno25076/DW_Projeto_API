using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemberAndSubscriptionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AppUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }
    }
}
