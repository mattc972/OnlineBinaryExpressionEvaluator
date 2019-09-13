using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBinaryExpressionEvaluator.Migrations
{
    public partial class NegationResult1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NegationResult",
                table: "Expression",
                newName: "NegationResult2");

            migrationBuilder.AddColumn<string>(
                name: "NegationResult1",
                table: "Expression",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegationResult1",
                table: "Expression");

            migrationBuilder.RenameColumn(
                name: "NegationResult2",
                table: "Expression",
                newName: "NegationResult");
        }
    }
}
