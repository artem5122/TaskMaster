using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class SolutionMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Solution",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solution_AuthorId",
                table: "Solution",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solution_Account_AuthorId",
                table: "Solution",
                column: "AuthorId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solution_Account_AuthorId",
                table: "Solution");

            migrationBuilder.DropIndex(
                name: "IX_Solution_AuthorId",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Solution");
        }
    }
}
