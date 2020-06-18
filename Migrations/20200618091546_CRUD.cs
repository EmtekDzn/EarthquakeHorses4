using Microsoft.EntityFrameworkCore.Migrations;

namespace EarthquakeHorses4.Migrations
{
    public partial class CRUD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Sceance_SceanceId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SceanceId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SceanceId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "SceanceUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SceanceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceanceUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceanceUser_Sceance_SceanceId",
                        column: x => x.SceanceId,
                        principalTable: "Sceance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceanceUser_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceanceUser_SceanceId",
                table: "SceanceUser",
                column: "SceanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SceanceUser_UserId1",
                table: "SceanceUser",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceanceUser");

            migrationBuilder.AddColumn<int>(
                name: "SceanceId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SceanceId",
                table: "User",
                column: "SceanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Sceance_SceanceId",
                table: "User",
                column: "SceanceId",
                principalTable: "Sceance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
