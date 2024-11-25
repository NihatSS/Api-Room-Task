using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_intro.Migrations
{
    public partial class CreatedRoomsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_RoomId",
                table: "Groups",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Rooms_RoomId",
                table: "Groups",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Rooms_RoomId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Groups_RoomId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Groups");
        }
    }
}
