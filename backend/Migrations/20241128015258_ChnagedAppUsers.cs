using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ChnagedAppUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignUserNotes_AspNetUsers_UserId",
                table: "CampaignUserNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignUserTasks_AspNetUsers_UserId",
                table: "CampaignUserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_AspNetUsers_UserId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUserNotes_AspNetUsers_UserId",
                table: "JobUserNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUserTasks_AspNetUsers_UserId",
                table: "JobUserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadActivities_AspNetUsers_CreatedByUserId",
                table: "LeadActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadHistory_AspNetUsers_UpdatedByUserId",
                table: "LeadHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_AppUserId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_AspNetUsers_UploadedByUserId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskAttachments_UploadedByUserId",
                table: "TaskAttachments");

            migrationBuilder.DropIndex(
                name: "IX_LeadHistory_UpdatedByUserId",
                table: "LeadHistory");

            migrationBuilder.DropIndex(
                name: "IX_LeadActivities_CreatedByUserId",
                table: "LeadActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UploadedByUserId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "LeadActivities");

            migrationBuilder.AddColumn<string>(
                name: "UploadedByUserAppUserId",
                table: "TaskAttachments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserAppUserId",
                table: "LeadHistory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserAppUserId",
                table: "LeadActivities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_UploadedByUserAppUserId",
                table: "TaskAttachments",
                column: "UploadedByUserAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_UpdatedByUserAppUserId",
                table: "LeadHistory",
                column: "UpdatedByUserAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivities_CreatedByUserAppUserId",
                table: "LeadActivities",
                column: "CreatedByUserAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignUserNotes_AspNetUsers_UserId",
                table: "CampaignUserNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignUserTasks_AspNetUsers_UserId",
                table: "CampaignUserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_AspNetUsers_UserId",
                table: "CustomerUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUserNotes_AspNetUsers_UserId",
                table: "JobUserNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUserTasks_AspNetUsers_UserId",
                table: "JobUserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadActivities_AspNetUsers_CreatedByUserAppUserId",
                table: "LeadActivities",
                column: "CreatedByUserAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadHistory_AspNetUsers_UpdatedByUserAppUserId",
                table: "LeadHistory",
                column: "UpdatedByUserAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_AppUserId",
                table: "RefreshToken",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_AspNetUsers_UploadedByUserAppUserId",
                table: "TaskAttachments",
                column: "UploadedByUserAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignUserNotes_AspNetUsers_UserId",
                table: "CampaignUserNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignUserTasks_AspNetUsers_UserId",
                table: "CampaignUserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_AspNetUsers_UserId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUserNotes_AspNetUsers_UserId",
                table: "JobUserNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUserTasks_AspNetUsers_UserId",
                table: "JobUserTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadActivities_AspNetUsers_CreatedByUserAppUserId",
                table: "LeadActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadHistory_AspNetUsers_UpdatedByUserAppUserId",
                table: "LeadHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_AppUserId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_AspNetUsers_UploadedByUserAppUserId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskAttachments_UploadedByUserAppUserId",
                table: "TaskAttachments");

            migrationBuilder.DropIndex(
                name: "IX_LeadHistory_UpdatedByUserAppUserId",
                table: "LeadHistory");

            migrationBuilder.DropIndex(
                name: "IX_LeadActivities_CreatedByUserAppUserId",
                table: "LeadActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UploadedByUserAppUserId",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserAppUserId",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "CreatedByUserAppUserId",
                table: "LeadActivities");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UploadedByUserId",
                table: "TaskAttachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "LeadHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "LeadActivities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_UploadedByUserId",
                table: "TaskAttachments",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_UpdatedByUserId",
                table: "LeadHistory",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivities_CreatedByUserId",
                table: "LeadActivities",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignUserNotes_AspNetUsers_UserId",
                table: "CampaignUserNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignUserTasks_AspNetUsers_UserId",
                table: "CampaignUserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_AspNetUsers_UserId",
                table: "CustomerUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUserNotes_AspNetUsers_UserId",
                table: "JobUserNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUsers_AspNetUsers_UserId",
                table: "JobUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUserTasks_AspNetUsers_UserId",
                table: "JobUserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadActivities_AspNetUsers_CreatedByUserId",
                table: "LeadActivities",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadHistory_AspNetUsers_UpdatedByUserId",
                table: "LeadHistory",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_AppUserId",
                table: "RefreshToken",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_AspNetUsers_UploadedByUserId",
                table: "TaskAttachments",
                column: "UploadedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_AspNetUsers_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
