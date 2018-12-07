using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Associado.Repositories.Migrations
{
    public partial class AssociadosM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Associado",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    cidade = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    ceep = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    descProblema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AssociadoDTO",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    descProblema = table.Column<string>(nullable: true),
                    ceep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociadoDTO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    nome = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    grau = table.Column<string>(nullable: true),
                    Associadid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dependente_Associado_Associadid",
                        column: x => x.Associadid,
                        principalTable: "Associado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_Associadid",
                table: "Dependente",
                column: "Associadid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociadoDTO");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Associado");
        }
    }
}
