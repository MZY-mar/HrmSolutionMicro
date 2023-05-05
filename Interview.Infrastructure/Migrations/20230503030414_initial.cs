using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FristName = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FristName = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    InterviewTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterviewRound = table.Column<int>(type: "int", nullable: false),
                    ScheduledOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewerId = table.Column<int>(type: "int", nullable: false),
                    FeedbackId = table.Column<int>(type: "int", nullable: false),
                    interviewTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewFeedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "InterviewFeedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewTypes_interviewTypeId",
                        column: x => x.interviewTypeId,
                        principalTable: "InterviewTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Interviews_Interviewers_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Interviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_FeedbackId",
                table: "Interviews",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_interviewTypeId",
                table: "Interviews",
                column: "interviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_RecruiterId",
                table: "Interviews",
                column: "RecruiterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "InterviewFeedbacks");

            migrationBuilder.DropTable(
                name: "InterviewTypes");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.DropTable(
                name: "Recruiters");
        }
    }
}
