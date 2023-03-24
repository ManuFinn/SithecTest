using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "humanotable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "latin1"),
                    Sexo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "latin1"),
                    Edad = table.Column<int>(type: "int(3)", nullable: false),
                    Altura = table.Column<int>(type: "int(5)", nullable: false),
                    Peso = table.Column<int>(type: "int(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_humanotable", x => x.id);
                })
                .Annotation("MySql:CharSet", "latin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "humanotable");
        }
    }
}
