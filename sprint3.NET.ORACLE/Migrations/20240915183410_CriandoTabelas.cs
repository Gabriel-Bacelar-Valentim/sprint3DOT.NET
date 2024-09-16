using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sprint3.NET.Database.Migrations
{

    public partial class CriandoTabelas : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Usuarios_sprint3",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NomeCompleto = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Usuarios_sprint3", x => x.Usuario_Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Agricultores_sprint3",
                columns: table => new
                {
                    Agricultor_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Agricultores_sprint3", x => x.Agricultor_Id);
                    table.ForeignKey(
                        name: "FK_TB_Agricultores_sprint3_TB_Usuarios_sprint3_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_Usuarios_sprint3",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Fazendas_sprint3",
                columns: table => new
                {
                    Fazenda_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AgricultorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TamanhoHectares = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Fazendas_sprint3", x => x.Fazenda_Id);
                    table.ForeignKey(
                        name: "FK_TB_Fazendas_sprint3_TB_Agricultores_sprint3_AgricultorId",
                        column: x => x.AgricultorId,
                        principalTable: "TB_Agricultores_sprint3",
                        principalColumn: "Agricultor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Safra",
                columns: table => new
                {
                    Safra_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FazendaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Cultura = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ano = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantidadeProduzida = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safra", x => x.Safra_Id);
                    table.ForeignKey(
                        name: "FK_Safra_TB_Fazendas_sprint3_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "TB_Fazendas_sprint3",
                        principalColumn: "Fazenda_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solo",
                columns: table => new
                {
                    Solo_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FazendaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoSolo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PH = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NivelNitrogenio = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NivelPotassio = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solo", x => x.Solo_Id);
                    table.ForeignKey(
                        name: "FK_Solo_TB_Fazendas_sprint3_FazendaId",
                        column: x => x.FazendaId,
                        principalTable: "TB_Fazendas_sprint3",
                        principalColumn: "Fazenda_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Safra_FazendaId",
                table: "Safra",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solo_FazendaId",
                table: "Solo",
                column: "FazendaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Agricultores_sprint3_UsuarioId",
                table: "TB_Agricultores_sprint3",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fazendas_sprint3_AgricultorId",
                table: "TB_Fazendas_sprint3",
                column: "AgricultorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Safra");

            migrationBuilder.DropTable(
                name: "Solo");

            migrationBuilder.DropTable(
                name: "TB_Fazendas_sprint3");

            migrationBuilder.DropTable(
                name: "TB_Agricultores_sprint3");

            migrationBuilder.DropTable(
                name: "TB_Usuarios_sprint3");
        }
    }
}
