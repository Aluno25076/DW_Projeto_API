using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW_Projeto_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMatchEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surface = table.Column<int>(type: "int", nullable: false),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    FieldFK = table.Column<int>(type: "int", nullable: false),
                    EmployeeFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Employees_EmployeeFK",
                        column: x => x.EmployeeFK,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Fields_FieldFK",
                        column: x => x.FieldFK,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_EmployeeFK",
                table: "Matches",
                column: "EmployeeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FieldFK",
                table: "Matches",
                column: "FieldFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Matches_MatchId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_MatchId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "AppUsers");
        }
    }
}
