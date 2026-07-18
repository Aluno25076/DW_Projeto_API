using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class TennisFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Fields_FieldFK",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "TennisFields");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TennisFields",
                table: "TennisFields",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetScores = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Winner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatchFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Matches_MatchFK",
                        column: x => x.MatchFK,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_MatchFK",
                table: "Results",
                column: "MatchFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TennisFields_FieldFK",
                table: "Matches",
                column: "FieldFK",
                principalTable: "TennisFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TennisFields_FieldFK",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TennisFields",
                table: "TennisFields");

            migrationBuilder.RenameTable(
                name: "TennisFields",
                newName: "Fields");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Fields_FieldFK",
                table: "Matches",
                column: "FieldFK",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
