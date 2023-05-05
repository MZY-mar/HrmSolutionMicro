using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onboarding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    ABBR = table.Column<string>(type: "nvarchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    ABBR = table.Column<string>(type: "nvarchar(9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EmployeeRoleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: false),
                    EmployeeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeStatuses_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_employeeCategories_EmployeeCategoryId",
                        column: x => x.EmployeeCategoryId,
                        principalTable: "employeeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCategoryId",
                table: "Employees",
                column: "EmployeeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeRoleId",
                table: "Employees",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");

            migrationBuilder.DropTable(
                name: "employeeCategories");
        }
    }
}
