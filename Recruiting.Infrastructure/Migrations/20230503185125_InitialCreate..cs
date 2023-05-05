using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruiting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Mobile = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(70)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPosition = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(70)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    HiringManagerId = table.Column<int>(type: "int", nullable: false),
                    HiringManagerName = table.Column<string>(type: "varchar(20)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedReason = table.Column<string>(type: "varchar(70)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequirements_jobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "jobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRequirementId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentStatus = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_JobRequirements_JobRequirementId",
                        column: x => x.JobRequirementId,
                        principalTable: "JobRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmissionStatus_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_JobCategoryId",
                table: "JobRequirements",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submissions",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_JobRequirementId",
                table: "Submissions",
                column: "JobRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionStatus_SubmissionId",
                table: "SubmissionStatus",
                column: "SubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmissionStatus");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "JobRequirements");

            migrationBuilder.DropTable(
                name: "jobCategories");
        }
    }
}
