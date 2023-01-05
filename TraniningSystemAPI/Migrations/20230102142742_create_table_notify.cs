using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraniningSystemAPI.Migrations
{
    public partial class create_table_notify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "ClassroomDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notify",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ReciveId = table.Column<int>(type: "int", nullable: true),
                    ConfirmId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notify", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notify_Account_ConfirmId",
                        column: x => x.ConfirmId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notify_Account_ReciveId",
                        column: x => x.ReciveId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notify_ConfirmId",
                table: "Notify",
                column: "ConfirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Notify_ReciveId",
                table: "Notify",
                column: "ReciveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notify");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "ClassroomDetail");
        }
    }
}
