using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Event.Migrations
{
    /// <inheritdoc />
    public partial class DbProjectEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Institucaoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Institucaoid);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeEvento",
                columns: table => new
                {
                    TipoDeEventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeEvento", x => x.TipoDeEventoid);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeUsuario",
                columns: table => new
                {
                    TipoDeUsuarioid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeUsuario", x => x.TipoDeUsuarioid);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Eventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    DescricaoEvento = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDeEventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Instituicaoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Eventoid);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_Instituicaoid",
                        column: x => x.Instituicaoid,
                        principalTable: "Instituicao",
                        principalColumn: "Institucaoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TipoDeEvento_TipoDeEventoid",
                        column: x => x.TipoDeEventoid,
                        principalTable: "TipoDeEvento",
                        principalColumn: "TipoDeEventoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usuarioid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SenhaUsuario = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoDeUsuarioid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usuarioid);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoDeUsuario_TipoDeUsuarioid",
                        column: x => x.TipoDeUsuarioid,
                        principalTable: "TipoDeUsuario",
                        principalColumn: "TipoDeUsuarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    ComentarioEventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    Usuarioid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Eventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.ComentarioEventoid);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "Eventoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    Presencaid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false),
                    Usuarioid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Eventoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.Presencaid);
                    table.ForeignKey(
                        name: "FK_Presenca_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "Eventoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_Eventoid",
                table: "ComentarioEvento",
                column: "Eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_Exibe",
                table: "ComentarioEvento",
                column: "Exibe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_Usuarioid",
                table: "ComentarioEvento",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Instituicaoid",
                table: "Evento",
                column: "Instituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoDeEventoid",
                table: "Evento",
                column: "TipoDeEventoid");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_Eventoid",
                table: "Presenca",
                column: "Eventoid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_Situacao",
                table: "Presenca",
                column: "Situacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_Usuarioid",
                table: "Presenca",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmailUsuario",
                table: "Usuario",
                column: "EmailUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoDeUsuarioid",
                table: "Usuario",
                column: "TipoDeUsuarioid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoDeEvento");

            migrationBuilder.DropTable(
                name: "TipoDeUsuario");
        }
    }
}
