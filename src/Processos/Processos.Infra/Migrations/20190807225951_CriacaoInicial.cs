using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Processos.Infra.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    ProcessoIdentificador = table.Column<Guid>(nullable: true),
                    EtapaEntradaIdentificador = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Etapa_Etapa_EtapaEntradaIdentificador",
                        column: x => x.EtapaEntradaIdentificador,
                        principalTable: "Etapa",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etapa_Processo_ProcessoIdentificador",
                        column: x => x.ProcessoIdentificador,
                        principalTable: "Processo",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parada",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    EtapaIdentificador = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parada", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Parada_Etapa_EtapaIdentificador",
                        column: x => x.EtapaIdentificador,
                        principalTable: "Etapa",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Problema",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    EtapaIdentificador = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problema", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Problema_Etapa_EtapaIdentificador",
                        column: x => x.EtapaIdentificador,
                        principalTable: "Etapa",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etapa_EtapaEntradaIdentificador",
                table: "Etapa",
                column: "EtapaEntradaIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Etapa_ProcessoIdentificador",
                table: "Etapa",
                column: "ProcessoIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Parada_EtapaIdentificador",
                table: "Parada",
                column: "EtapaIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Problema_EtapaIdentificador",
                table: "Problema",
                column: "EtapaIdentificador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parada");

            migrationBuilder.DropTable(
                name: "Problema");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Processo");
        }
    }
}
