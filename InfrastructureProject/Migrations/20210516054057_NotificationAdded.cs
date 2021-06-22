using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureProject.Migrations
{
    public partial class NotificationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userfromId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    postId = table.Column<int>(type: "int", nullable: true),
                    usertoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_notifications_AspNetUsers_userfromId",
                        column: x => x.userfromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notifications_AspNetUsers_usertoId",
                        column: x => x.usertoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notifications_jobposts_postId",
                        column: x => x.postId,
                        principalTable: "jobposts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notifications_postId",
                table: "notifications",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_userfromId",
                table: "notifications",
                column: "userfromId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_usertoId",
                table: "notifications",
                column: "usertoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
