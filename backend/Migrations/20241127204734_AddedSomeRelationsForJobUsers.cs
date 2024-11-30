using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeRelationsForJobUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId1",
                table: "JobUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobUsers",
                table: "JobUsers");

            migrationBuilder.DropIndex(
                name: "IX_JobUsers_UserId1",
                table: "JobUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "JobUsers");

            migrationBuilder.RenameColumn(
                name: "JobUsersId",
                table: "JobUsers",
                newName: "JobUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JobUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobUsers",
                table: "JobUsers",
                columns: new[] { "UserId", "JobId", "JobUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobUsers",
                table: "JobUsers");

            migrationBuilder.RenameColumn(
                name: "JobUserId",
                table: "JobUsers",
                newName: "JobUsersId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "JobUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "JobUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobUsers",
                table: "JobUsers",
                columns: new[] { "UserId", "JobId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobUsers_UserId1",
                table: "JobUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId1",
                table: "JobUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
