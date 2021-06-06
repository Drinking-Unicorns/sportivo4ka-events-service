using Microsoft.EntityFrameworkCore.Migrations;

namespace sportivo4ka.Events.BI.Migrations
{
    public partial class AddCodeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeType",
                table: "UsersActivity",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeType",
                table: "UsersActivity");
        }
    }
}
