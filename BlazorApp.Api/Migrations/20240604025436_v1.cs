using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(32)", maxLength: 32, nullable: false),
                    IsAdmin = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NroTelefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneEmpresa", x => new { x.EmpresaId, x.NroTelefone });
                    table.ForeignKey(
                        name: "FK_TelefoneEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoUsuario",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoUsuario", x => new { x.AlunosId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_AlunoUsuario_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoUsuario",
                columns: table => new
                {
                    CursosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoUsuario", x => new { x.CursosId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Curso_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaUsuario",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUsuario", x => new { x.EmpresasId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Empresa_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrutorUsuario",
                columns: table => new
                {
                    InstrutoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrutorUsuario", x => new { x.InstrutoresId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_InstrutorUsuario_Instrutor_InstrutoresId",
                        column: x => x.InstrutoresId,
                        principalTable: "Instrutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrutorUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConteudoProgramaticoUsuario",
                columns: table => new
                {
                    ConteudosProgramaticosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConteudoProgramaticoUsuario", x => new { x.ConteudosProgramaticosId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_ConteudoProgramaticoUsuario_ConteudoProgramatico_ConteudosProgramaticosId",
                        column: x => x.ConteudosProgramaticosId,
                        principalTable: "ConteudoProgramatico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConteudoProgramaticoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvaUsuario",
                columns: table => new
                {
                    ProvasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaUsuario", x => new { x.ProvasId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_ProvaUsuario_Prova_ProvasId",
                        column: x => x.ProvasId,
                        principalTable: "Prova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "TreinamentoUsuario",
                columns: table => new
                {
                    TreinamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinamentoUsuario", x => new { x.TreinamentosId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_TreinamentoUsuario_Treinamento_TreinamentosId",
                        column: x => x.TreinamentosId,
                        principalTable: "Treinamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreinamentoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoEmpresaUsuario",
                columns: table => new
                {
                    EnderecosEmpresasEmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEmpresaUsuario", x => new { x.EnderecosEmpresasEmpresaId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresaUsuario_EnderecoEmpresa_EnderecosEmpresasEmpresaId",
                        column: x => x.EnderecosEmpresasEmpresaId,
                        principalTable: "EnderecoEmpresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefoneEmpresaUsuario",
                columns: table => new
                {
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    TelefonesEmpresasEmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TelefonesEmpresasNroTelefone = table.Column<string>(type: "VARCHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneEmpresaUsuario", x => new { x.UsuariosUsuarioId, x.TelefonesEmpresasEmpresaId, x.TelefonesEmpresasNroTelefone });
                    table.ForeignKey(
                        name: "FK_TelefoneEmpresaUsuario_TelefoneEmpresa_TelefonesEmpresasEmpresaId_TelefonesEmpresasNroTelefone",
                        columns: x => new { x.TelefonesEmpresasEmpresaId, x.TelefonesEmpresasNroTelefone },
                        principalTable: "TelefoneEmpresa",
                        principalColumns: new[] { "EmpresaId", "NroTelefone" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TelefoneEmpresaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
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
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "QuestaoUsuario",
                columns: table => new
                {
                    QuestoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoUsuario", x => new { x.QuestoesId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_QuestaoUsuario_Questao_QuestoesId",
                        column: x => x.QuestoesId,
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificadoUsuario",
                columns: table => new
                {
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CertificadosTreinamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificadosCodigo = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadoUsuario", x => new { x.UsuariosUsuarioId, x.CertificadosTreinamentoId, x.CertificadosCodigo });
                    table.ForeignKey(
                        name: "FK_CertificadoUsuario_Certificado_CertificadosTreinamentoId_CertificadosCodigo",
                        columns: x => new { x.CertificadosTreinamentoId, x.CertificadosCodigo },
                        principalTable: "Certificado",
                        principalColumns: new[] { "TreinamentoId", "Codigo" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadoUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaPresencaUsuario",
                columns: table => new
                {
                    ListasPresescasTreinamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPresencaUsuario", x => new { x.ListasPresescasTreinamentoId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_ListaPresencaUsuario_ListaPresenca_ListasPresescasTreinamentoId",
                        column: x => x.ListasPresescasTreinamentoId,
                        principalTable: "ListaPresenca",
                        principalColumn: "TreinamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaPresencaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternativaUsuario",
                columns: table => new
                {
                    AlternativasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosUsuarioId = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativaUsuario", x => new { x.AlternativasId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_AlternativaUsuario_Alternativa_AlternativasId",
                        column: x => x.AlternativasId,
                        principalTable: "Alternativa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlternativaUsuario_Usuario_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Assinatura", "Cpf", "DataAlteracao", "DataCriacao", "Email", "Nome", "Rg", "Status", "Telefone", "UsuarioId" },
                values: new object[] { new Guid("1b5d254e-45cb-4c4f-8fd7-c1e2f5a15f2d"), "Assin1", "000.111.00011", null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(2267), "", "Aluno Teste 1", "", 1, "", "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHorariaInicial", "CargaHorariaPeriodico", "DataAlteracao", "DataCriacao", "Logo", "Nome", "Status", "UsuarioId", "Validade" },
                values: new object[] { new Guid("9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17"), (short)4, (short)8, null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(2706), "", "Curso Teste 01", (short)1, "UsuarioTeste01@teste.com", (short)2 });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "CNPJ", "DataAlteracao", "DataCriacao", "Email", "RazaoSocial", "Status", "UsuarioId" },
                values: new object[] { new Guid("7a9e5f7d-2c6e-4a1b-bc3f-4d5a1e2f5b6c"), "11.000.111/0001-10", null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(3520), "", "Empresa Teste 01", (short)1, "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Instrutor",
                columns: new[] { "Id", "Assinatura", "Cpf", "DataAlteracao", "DataCriacao", "Email", "Especializacao", "Nome", "Registro", "Status", "Telefone", "UsuarioId" },
                values: new object[] { new Guid("2f1b6d4e-8e7f-4a5d-9f1c-7c3e5d6b8f1a"), "", "222.000.22202", null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(3753), "", "Técnico de Segurança", "Instrutor Teste 01", "CAEPF01/542", (short)1, "(11) 991276269", "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "DataAlteracao", "DataCriacao", "IsAdmin", "Nome", "Senha", "Status" },
                values: new object[,]
                {
                    { "TesteUsuario02@teste.com", null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(3887), (short)1, "Usuario 02", "aqgbpo23", 1 },
                    { "UsuarioTeste01@teste.com", null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(3879), (short)1, "Usuario 01", "aqgbpo22", 1 }
                });

            migrationBuilder.InsertData(
                table: "Prova",
                columns: new[] { "Id", "CursoId", "DataAlteracao", "DataCriacao", "Status", "UsuarioId" },
                values: new object[] { new Guid("3e6d2f3a-5f57-4c97-85c1-8f5d1b6c4d71"), new Guid("9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17"), null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(2850), (short)1, "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Treinamento",
                columns: new[] { "Id", "CursoId", "DataAlteracao", "DataCriacao", "Situacao", "Status", "Tipo", "UsuarioId" },
                values: new object[] { new Guid("d4f354e8-6e64-4b2c-91f5-99c5a6e5d7c1"), new Guid("9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17"), null, new DateTime(2024, 6, 3, 23, 54, 35, 791, DateTimeKind.Local).AddTicks(2573), (short)1, (short)1, (short)1, "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Questao",
                columns: new[] { "Id", "Conteudo", "ProvaId", "Status", "UsuarioId" },
                values: new object[] { new Guid("b5aefd22-7c2e-42e5-9316-8f09d5f2c0f1"), "Questao 01", new Guid("3e6d2f3a-5f57-4c97-85c1-8f5d1b6c4d71"), (short)1, "UsuarioTeste01@teste.com" });

            migrationBuilder.InsertData(
                table: "Alternativa",
                columns: new[] { "Id", "Conteudo", "QuestaoId", "Resposta", "Status", "UsuarioId" },
                values: new object[] { new Guid("8d7e2f3c-0d29-4d61-97f1-3453b6f7d631"), "alternativa A", new Guid("b5aefd22-7c2e-42e5-9316-8f09d5f2c0f1"), (short)1, (short)1, "UsuarioTeste01@teste.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativa_QuestaoId",
                table: "Alternativa",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlternativaUsuario_UsuariosUsuarioId",
                table: "AlternativaUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoEmpresa_EmpresasId",
                table: "AlunoEmpresa",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTreinamento_TreinamentosId",
                table: "AlunoTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoUsuario_UsuariosUsuarioId",
                table: "AlunoUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadoUsuario_CertificadosTreinamentoId_CertificadosCodigo",
                table: "CertificadoUsuario",
                columns: new[] { "CertificadosTreinamentoId", "CertificadosCodigo" });

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoProgramatico_CursoId",
                table: "ConteudoProgramatico",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConteudoProgramaticoUsuario_UsuariosUsuarioId",
                table: "ConteudoProgramaticoUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_UsuariosUsuarioId",
                table: "CursoUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaTreinamento_TreinamentosId",
                table: "EmpresaTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUsuario_UsuariosUsuarioId",
                table: "EmpresaUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEmpresaUsuario_UsuariosUsuarioId",
                table: "EnderecoEmpresaUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrutorTreinamento_TreinamentosId",
                table: "InstrutorTreinamento",
                column: "TreinamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrutorUsuario_UsuariosUsuarioId",
                table: "InstrutorUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaPresencaUsuario_UsuariosUsuarioId",
                table: "ListaPresencaUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prova_CursoId",
                table: "Prova",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvaUsuario_UsuariosUsuarioId",
                table: "ProvaUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_ProvaId",
                table: "Questao",
                column: "ProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoUsuario_UsuariosUsuarioId",
                table: "QuestaoUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefoneEmpresaUsuario_TelefonesEmpresasEmpresaId_TelefonesEmpresasNroTelefone",
                table: "TelefoneEmpresaUsuario",
                columns: new[] { "TelefonesEmpresasEmpresaId", "TelefonesEmpresasNroTelefone" });

            migrationBuilder.CreateIndex(
                name: "IX_Treinamento_CursoId",
                table: "Treinamento",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TreinamentoUsuario_UsuariosUsuarioId",
                table: "TreinamentoUsuario",
                column: "UsuariosUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlternativaUsuario");

            migrationBuilder.DropTable(
                name: "AlunoEmpresa");

            migrationBuilder.DropTable(
                name: "AlunoTreinamento");

            migrationBuilder.DropTable(
                name: "AlunoUsuario");

            migrationBuilder.DropTable(
                name: "CertificadoUsuario");

            migrationBuilder.DropTable(
                name: "ConteudoProgramaticoUsuario");

            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.DropTable(
                name: "EmpresaTreinamento");

            migrationBuilder.DropTable(
                name: "EmpresaUsuario");

            migrationBuilder.DropTable(
                name: "EnderecoEmpresaUsuario");

            migrationBuilder.DropTable(
                name: "InstrutorTreinamento");

            migrationBuilder.DropTable(
                name: "InstrutorUsuario");

            migrationBuilder.DropTable(
                name: "ListaPresencaUsuario");

            migrationBuilder.DropTable(
                name: "ProvaUsuario");

            migrationBuilder.DropTable(
                name: "QuestaoUsuario");

            migrationBuilder.DropTable(
                name: "TelefoneEmpresaUsuario");

            migrationBuilder.DropTable(
                name: "TreinamentoUsuario");

            migrationBuilder.DropTable(
                name: "Alternativa");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "ConteudoProgramatico");

            migrationBuilder.DropTable(
                name: "EnderecoEmpresa");

            migrationBuilder.DropTable(
                name: "Instrutor");

            migrationBuilder.DropTable(
                name: "ListaPresenca");

            migrationBuilder.DropTable(
                name: "TelefoneEmpresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Questao");

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
