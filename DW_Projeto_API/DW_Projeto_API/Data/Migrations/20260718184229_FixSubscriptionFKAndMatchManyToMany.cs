using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSubscriptionFKAndMatchManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionFK",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MatchMember",
                columns: table => new
                {
                    MatchesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMember", x => new { x.MatchesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_MatchMember_AppUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchMember_Matches_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubscriptionFK",
                table: "AppUsers",
                column: "SubscriptionFK");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMember_ParticipantsId",
                table: "MatchMember",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionFK",
                table: "AppUsers",
                column: "SubscriptionFK",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionFK",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "MatchMember");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_SubscriptionFK",
                table: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionFK",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Subscriptions_SubscriptionId",
                table: "AppUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }
    }
}
