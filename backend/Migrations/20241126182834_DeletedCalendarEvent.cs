using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class DeletedCalendarEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEvent");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "CalendarEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventFor = table.Column<int>(type: "int", nullable: false),
                    JobsJobId = table.Column<int>(type: "int", nullable: false),
                    JobsAssignedTo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobsCustomerId = table.Column<int>(type: "int", nullable: false),
                    JobsLastUpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobsCreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvent", x => new { x.EventId, x.CreatedBy, x.EventFor });
                    table.ForeignKey(
                        name: "FK_CalendarEvent_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_Customers_EventFor",
                        column: x => x.EventFor,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_Jobs_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                        columns: x => new { x.JobsJobId, x.JobsAssignedTo, x.JobsCustomerId, x.JobsLastUpdatedBy, x.JobsCreatedBy },
                        principalTable: "Jobs",
                        principalColumns: new[] { "JobId", "AssignedTo", "CustomerId", "LastUpdatedBy", "CreatedBy" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_CreatedBy",
                table: "CalendarEvent",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_EventFor",
                table: "CalendarEvent",
                column: "EventFor");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_JobsJobId_JobsAssignedTo_JobsCustomerId_JobsLastUpdatedBy_JobsCreatedBy",
                table: "CalendarEvent",
                columns: new[] { "JobsJobId", "JobsAssignedTo", "JobsCustomerId", "JobsLastUpdatedBy", "JobsCreatedBy" });
        }
    }
}
