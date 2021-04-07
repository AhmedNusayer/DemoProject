using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureProject.Migrations
{
    public partial class JobPostsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobposts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPosts = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryRangeStart = table.Column<int>(type: "int", nullable: false),
                    SalaryRangeEnd = table.Column<int>(type: "int", nullable: false),
                    TimeofPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostAuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobposts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobposts_AspNetUsers_PostAuthorId",
                        column: x => x.PostAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_jobposts_companies_CompanyInfoId",
                        column: x => x.CompanyInfoId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobposts_CompanyInfoId",
                table: "jobposts",
                column: "CompanyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_jobposts_PostAuthorId",
                table: "jobposts",
                column: "PostAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobposts");
        }
    }
}
