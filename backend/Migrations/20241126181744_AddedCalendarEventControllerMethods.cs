using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedCalendarEventControllerMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_AspNetUsers_CreatedBy",
                table: "CalendarEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_Customers_EventFor",
                table: "CalendarEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents");

            migrationBuilder.RenameTable(
                name: "CalendarEvents",
                newName: "CalendarEvent");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvents_EventFor",
                table: "CalendarEvent",
                newName: "IX_CalendarEvent_EventFor");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvents_CreatedBy",
                table: "CalendarEvent",
                newName: "IX_CalendarEvent_CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "CalendarEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobsAssignedTo",
                table: "CalendarEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobsCreatedBy",
                table: "CalendarEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobsCustomerId",
                table: "CalendarEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobsJobId",
                table: "CalendarEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobsLastUpdatedBy",
                table: "CalendarEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CalendarEvent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEvent",
                table: "CalendarEvent",
                columns: new[] { "EventId", "CreatedBy", "EventFor" });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                table: "CalendarEvent",
                columns: new[] { "JobsJobId", "JobsAssignedTo", "JobsCustomerId", "JobsLastUpdatedBy", "JobsCreatedBy" });

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_CreatedBy",
                table: "CalendarEvent",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_Customers_EventFor",
                table: "CalendarEvent",
                column: "EventFor",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_Jobs_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                table: "CalendarEvent",
                columns: new[] { "JobsJobId", "JobsAssignedTo", "JobsCustomerId", "JobsLastUpdatedBy", "JobsCreatedBy" },
                principalTable: "Jobs",
                principalColumns: new[] { "JobId", "AssignedTo", "CustomerId", "LastUpdatedBy", "CreatedBy" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_CreatedBy",
                table: "CalendarEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_Customers_EventFor",
                table: "CalendarEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_Jobs_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                table: "CalendarEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEvent",
                table: "CalendarEvent");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEvent_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobsAssignedTo",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobsCreatedBy",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobsCustomerId",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobsJobId",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "JobsLastUpdatedBy",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CalendarEvent");

            migrationBuilder.RenameTable(
                name: "CalendarEvent",
                newName: "CalendarEvents");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvent_EventFor",
                table: "CalendarEvents",
                newName: "IX_CalendarEvents_EventFor");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvent_CreatedBy",
                table: "CalendarEvents",
                newName: "IX_CalendarEvents_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents",
                columns: new[] { "EventId", "CreatedBy", "EventFor" });

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_AspNetUsers_CreatedBy",
                table: "CalendarEvents",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_Customers_EventFor",
                table: "CalendarEvents",
                column: "EventFor",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
