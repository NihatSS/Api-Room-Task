using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_intro.Migrations
{
    public partial class ChangedGroupsPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
