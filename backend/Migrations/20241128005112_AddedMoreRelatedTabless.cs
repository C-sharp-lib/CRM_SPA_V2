using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreRelatedTabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeadActivities_Leads_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadHistory_Leads_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_AspNetUsers_AssignedToUserId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_AspNetUsers_UpdatedByUserId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Customers_CustomerId1",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId1_TaskCreatedBy_TaskUpdatedBy_TaskAssignedTo",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AssignedToUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UpdatedByUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedToUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedBy",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UpdatedByUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskAttachments_TaskId1_TaskCreatedBy_TaskUpdatedBy_TaskAssignedTo",
                table: "TaskAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_AssignedToUserId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CustomerId1",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_UpdatedByUserId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_LeadHistory_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadHistory");

            migrationBuilder.DropIndex(
                name: "IX_LeadActivities_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadActivities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAssignedTo",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "TaskCreatedBy",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "TaskUpdatedBy",
                table: "TaskAttachments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "LeadAssignedTo",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "LeadCustomerId",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "LeadId1",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "LeadUpdatedBy",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "LeadAssignedTo",
                table: "LeadActivities");

            migrationBuilder.DropColumn(
                name: "LeadCustomerId",
                table: "LeadActivities");

            migrationBuilder.DropColumn(
                name: "LeadId1",
                table: "LeadActivities");

            migrationBuilder.DropColumn(
                name: "LeadUpdatedBy",
                table: "LeadActivities");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                column: "LeadId");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Spend = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetAudience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevenueTarget = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ActualRevenue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Impressions = table.Column<long>(type: "bigint", nullable: false),
                    Clicks = table.Column<long>(type: "bigint", nullable: false),
                    LeadsGenerated = table.Column<int>(type: "int", nullable: false),
                    Conversions = table.Column<int>(type: "int", nullable: false),
                    ROI = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "JobUserNotes",
                columns: table => new
                {
                    JobUserNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUserNotes", x => new { x.JobUserNoteId, x.JobId, x.UserId, x.NoteId });
                    table.ForeignKey(
                        name: "FK_JobUserNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUserNotes_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUserNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobUserTasks",
                columns: table => new
                {
                    JobUserTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUserTasks", x => new { x.JobUserTaskId, x.JobId, x.UserId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_JobUserTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUserTasks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobUserTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    UserTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => new { x.UserId, x.TaskId, x.UserTaskId });
                    table.ForeignKey(
                        name: "FK_UserTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignUserNotes",
                columns: table => new
                {
                    CampaignUserNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUserNotes", x => new { x.CampaignUserNoteId, x.CampaignId, x.UserId, x.NoteId });
                    table.ForeignKey(
                        name: "FK_CampaignUserNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUserNotes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUserNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignUserTasks",
                columns: table => new
                {
                    CampaignUserTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUserTasks", x => new { x.TaskId, x.CampaignUserTaskId, x.UserId, x.CampaignId });
                    table.ForeignKey(
                        name: "FK_CampaignUserTasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUserTasks_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUserTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppUserId",
                table: "Tasks",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserNotes_CampaignId",
                table: "CampaignUserNotes",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserNotes_NoteId",
                table: "CampaignUserNotes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserNotes_UserId",
                table: "CampaignUserNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserTasks_CampaignId",
                table: "CampaignUserTasks",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUserTasks_UserId",
                table: "CampaignUserTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserNotes_JobId",
                table: "JobUserNotes",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserNotes_NoteId",
                table: "JobUserNotes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserNotes_UserId",
                table: "JobUserNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserTasks_JobId",
                table: "JobUserTasks",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserTasks_TaskId",
                table: "JobUserTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUserTasks_UserId",
                table: "JobUserTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_TaskId",
                table: "UserTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadActivities_Leads_LeadId",
                table: "LeadActivities",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadHistory_Leads_LeadId",
                table: "LeadHistory",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId",
                table: "TaskAttachments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeadActivities_Leads_LeadId",
                table: "LeadActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadHistory_Leads_LeadId",
                table: "LeadHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "CampaignUserNotes");

            migrationBuilder.DropTable(
                name: "CampaignUserTasks");

            migrationBuilder.DropTable(
                name: "JobUserNotes");

            migrationBuilder.DropTable(
                name: "JobUserTasks");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskAssignedTo",
                table: "TaskAttachments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskCreatedBy",
                table: "TaskAttachments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskId1",
                table: "TaskAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TaskUpdatedBy",
                table: "TaskAttachments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Leads",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Leads",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "Leads",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId",
                table: "Leads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Leads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadAssignedTo",
                table: "LeadHistory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeadCustomerId",
                table: "LeadHistory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LeadId1",
                table: "LeadHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LeadUpdatedBy",
                table: "LeadHistory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeadAssignedTo",
                table: "LeadActivities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeadCustomerId",
                table: "LeadActivities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LeadId1",
                table: "LeadActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LeadUpdatedBy",
                table: "LeadActivities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "UpdatedBy", "AssignedTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                columns: new[] { "UserId", "NoteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                columns: new[] { "LeadId", "CustomerId", "UpdatedBy", "AssignedTo" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToUserId",
                table: "Tasks",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedBy",
                table: "Tasks",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UpdatedByUserId",
                table: "Tasks",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAttachments_TaskId1_TaskCreatedBy_TaskUpdatedBy_TaskAssignedTo",
                table: "TaskAttachments",
                columns: new[] { "TaskId1", "TaskCreatedBy", "TaskUpdatedBy", "TaskAssignedTo" });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AssignedToUserId",
                table: "Leads",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CustomerId1",
                table: "Leads",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_UpdatedByUserId",
                table: "Leads",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistory_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadHistory",
                columns: new[] { "LeadId1", "LeadCustomerId", "LeadUpdatedBy", "LeadAssignedTo" });

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivities_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadActivities",
                columns: new[] { "LeadId1", "LeadCustomerId", "LeadUpdatedBy", "LeadAssignedTo" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeadActivities_Leads_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadActivities",
                columns: new[] { "LeadId1", "LeadCustomerId", "LeadUpdatedBy", "LeadAssignedTo" },
                principalTable: "Leads",
                principalColumns: new[] { "LeadId", "CustomerId", "UpdatedBy", "AssignedTo" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadHistory_Leads_LeadId1_LeadCustomerId_LeadUpdatedBy_LeadAssignedTo",
                table: "LeadHistory",
                columns: new[] { "LeadId1", "LeadCustomerId", "LeadUpdatedBy", "LeadAssignedTo" },
                principalTable: "Leads",
                principalColumns: new[] { "LeadId", "CustomerId", "UpdatedBy", "AssignedTo" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_AspNetUsers_AssignedToUserId",
                table: "Leads",
                column: "AssignedToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_AspNetUsers_UpdatedByUserId",
                table: "Leads",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Customers_CustomerId1",
                table: "Leads",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_Tasks_TaskId1_TaskCreatedBy_TaskUpdatedBy_TaskAssignedTo",
                table: "TaskAttachments",
                columns: new[] { "TaskId1", "TaskCreatedBy", "TaskUpdatedBy", "TaskAssignedTo" },
                principalTable: "Tasks",
                principalColumns: new[] { "TaskId", "CreatedBy", "UpdatedBy", "AssignedTo" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AssignedToUserId",
                table: "Tasks",
                column: "AssignedToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_CreatedBy",
                table: "Tasks",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UpdatedByUserId",
                table: "Tasks",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
