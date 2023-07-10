using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    TaskAuthorId = table.Column<int>(type: "int", nullable: false),
                    SolutionAuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Account_SolutionAuthorId",
                        column: x => x.SolutionAuthorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Task_Account_TaskAuthorId",
                        column: x => x.TaskAuthorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_SolutionAuthorId",
                table: "Task",
                column: "SolutionAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskAuthorId",
                table: "Task",
                column: "TaskAuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
