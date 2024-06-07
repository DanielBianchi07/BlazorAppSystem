using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Rg = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Assinatura = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Logo = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CargaHorariaInicial = table.Column<short>(type: "SMALLINT", nullable: false),
                    CargaHorariaPeriodico = table.Column<short>(type: "SMALLINT", nullable: false),
                    Validade = table.Column<short>(type: "SMALLINT", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR(19)", maxLength: 19, nullable: false),
                    RazaoSocial = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instrutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Especializacao = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Registro = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Assinatura = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    IsAdmin = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConteudoProgramatico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assunto = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    CargaHoraria = table.Column<short>(type: "SMALLINT", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteudoProgramatico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConteudoProgramatico_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prova_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treinamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tipo = table.Column<short>(type: "SMALLINT", nullable: false),
                    Situacao = table.Column<short>(type: "SMALLINT", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treinamento_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoEmpresa",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoEmpresa", x => new { x.AlunosId, x.EmpresasId });
                    table.ForeignKey(
                        name: "FK_AlunoEmpresa_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoEmpresa_Empresa_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEmpresa",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(48)", maxLength: 48, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(48)", maxLength: 48, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    NomeRua = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEmpresa", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefoneEmpresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NroTelefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefoneEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    ProvaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questao_Prova_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Prova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTreinamento",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreinamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTreinamento", x => new { x.AlunosId, x.TreinamentosId });
                    table.ForeignKey(
                        name: "FK_AlunoTreinamento_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTreinamento_Treinamento_TreinamentosId",
                        column: x => x.TreinamentosId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    TreinamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    DataInicioCertificado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => new { x.TreinamentoId, x.Codigo });
                    table.ForeignKey(
                        name: "FK_Certificado_Treinamento_TreinamentoId",
                        column: x => x.TreinamentoId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaTreinamento",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreinamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaTreinamento", x => new { x.EmpresasId, x.TreinamentosId });
                    table.ForeignKey(
                        name: "FK_EmpresaTreinamento_Empresa_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaTreinamento_Treinamento_TreinamentosId",
                        column: x => x.TreinamentosId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrutorTreinamento",
                columns: table => new
                {
                    InstrutoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreinamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrutorTreinamento", x => new { x.InstrutoresId, x.TreinamentosId });
                    table.ForeignKey(
                        name: "FK_InstrutorTreinamento_Instrutor_InstrutoresId",
                        column: x => x.InstrutoresId,
                        principalTable: "Instrutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrutorTreinamento_Treinamento_TreinamentosId",
                        column: x => x.TreinamentosId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaPresenca",
                columns: table => new
                {
                    TreinamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInicioTreinamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<short>(type: "SMALLINT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPresenca", x => x.TreinamentoId);
                    table.ForeignKey(
                        name: "FK_ListaPresenca_Treinamento_TreinamentoId",
                        column: x => x.TreinamentoId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternativa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Resposta = table.Column<short>(type: "SMALLINT", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternativa_Questao_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativa_QuestaoId",
                table: "Alternativa",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEmpresa_EmpresasId",
                table: "AlunoEmpresa",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTreinamento_TreinamentosId",
                table: "AlunoTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoProgramatico_CursoId",
                table: "ConteudoProgramatico",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaTreinamento_TreinamentosId",
                table: "EmpresaTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrutorTreinamento_TreinamentosId",
                table: "InstrutorTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Prova_CursoId",
                table: "Prova",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_ProvaId",
                table: "Questao",
                column: "ProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneEmpresa_EmpresaId",
                table: "TelefoneEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Treinamento_CursoId",
                table: "Treinamento",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternativa");

            migrationBuilder.DropTable(
                name: "AlunoEmpresa");

            migrationBuilder.DropTable(
                name: "AlunoTreinamento");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "ConteudoProgramatico");

            migrationBuilder.DropTable(
                name: "EmpresaTreinamento");

            migrationBuilder.DropTable(
                name: "EnderecoEmpresa");

            migrationBuilder.DropTable(
                name: "InstrutorTreinamento");

            migrationBuilder.DropTable(
                name: "ListaPresenca");

            migrationBuilder.DropTable(
                name: "TelefoneEmpresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Questao");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Instrutor");

            migrationBuilder.DropTable(
                name: "Treinamento");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Prova");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
