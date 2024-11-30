using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixingErrorsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_AspNetUsersId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUsersId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "JobUsers");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AspNetUsersId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AspNetUsersId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Jobs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUsers", x => new { x.UserId, x.JobId, x.JobUserId });
                    table.ForeignKey(
                        name: "FK_JobUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUsers_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AspNetUsersId",
                table: "Tasks",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AspNetUsersId",
                table: "Jobs",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUsers_JobId",
                table: "JobUsers",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_AspNetUsersId",
                table: "Jobs",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUsersId",
                table: "Tasks",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
