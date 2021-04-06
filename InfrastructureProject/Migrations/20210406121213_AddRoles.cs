using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureProject.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "AspNetRoles",
            columns: new string[] { "Id", "Name", "NormalizedName" },
            values: new string[]  { "1", "User", "USER" }
            );

            migrationBuilder.InsertData(table: "AspNetRoles",
            columns: new string[] { "Id", "Name", "NormalizedName" },
            values: new string[] { "2", "Employer", "EMPLOYER" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "AspNetRoles",
            keyColumn: "Name",
            keyValue: "User"
            );
            migrationBuilder.DeleteData(table: "AspNetRoles",
            keyColumn: "Name",
            keyValue: "Employer"
            );
        }
    }
}
