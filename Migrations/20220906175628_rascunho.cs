using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atvCarros0609.Migrations
{
    public partial class rascunho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    veiculosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proprietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    corVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modeloVe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.veiculosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
