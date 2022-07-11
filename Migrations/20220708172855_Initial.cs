using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebService.Financeiro.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gastos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    pagamento = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    local = table.Column<string>(nullable: true),
                    gasto_dia = table.Column<DateTime>(nullable: false),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gastos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gastos");
        }
    }
}
