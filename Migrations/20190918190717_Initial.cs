using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBinaryExpressionEvaluator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BinaryAddition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Operand1 = table.Column<string>(maxLength: 7, nullable: true),
                    Operand2 = table.Column<string>(maxLength: 7, nullable: true),
                    AdditionResult = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryAddition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BinaryMultiplication",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Operand1 = table.Column<string>(maxLength: 4, nullable: true),
                    Operand2 = table.Column<string>(maxLength: 4, nullable: true),
                    MultiplicationResult = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryMultiplication", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BinaryNegation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Operand = table.Column<string>(maxLength: 7, nullable: true),
                    NegationResult = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryNegation", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinaryAddition");

            migrationBuilder.DropTable(
                name: "BinaryMultiplication");

            migrationBuilder.DropTable(
                name: "BinaryNegation");
        }
    }
}
