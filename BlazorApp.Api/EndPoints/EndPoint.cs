using BlazorApp.Api.Common.Api;
using BlazorApp.Api.EndPoints.Alternativas;
using BlazorApp.Api.EndPoints.Alunos;
using BlazorApp.Api.EndPoints.Certificados;
using BlazorApp.Api.EndPoints.ConteudosProgramaticos;
using BlazorApp.Api.EndPoints.Cursos;
using BlazorApp.Api.EndPoints.Empresas;
using BlazorApp.Api.EndPoints.EnderecosEmpresas;
using BlazorApp.Api.EndPoints.Instrutores;
using BlazorApp.Api.EndPoints.ListasPresencas;
using BlazorApp.Api.EndPoints.Provas;
using BlazorApp.Api.EndPoints.Questoes;
using BlazorApp.Api.EndPoints.TelefonesEmpresas;
using BlazorApp.Api.EndPoints.Treinamentos;
using BlazorApp.Api.EndPoints.Usuarios;
using Microsoft.AspNetCore.Routing;

namespace BlazorApp.Api.EndPoints
{
    public static class EndPoint
    {
        public static void MapEndPoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/").WithTags("Health Check").MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/alternativas")
                .WithTags("alternativas")
                .MapEndPoint<CreateAlternativaEndPoint>()
                .MapEndPoint<DeleteAlternativaEndPoint>()
                .MapEndPoint<UpdateAlternativaEndPoint>()
                .MapEndPoint<GetAlternativaByIdEndPoint>()
                .MapEndPoint<GetAlternativasByQuestaoEndPoint>();
                
            endpoints.MapGroup("v1/alunos")
                .WithTags("alunos")
                .MapEndPoint<CreateAlunoEndPoint>()
                .MapEndPoint<DeleteAlunoEndPoint>()
                .MapEndPoint<UpdateAlunoEndPoint>()
                .MapEndPoint<GetAlunoByIdEndPoint>()
                .MapEndPoint<GetAlunoByEmpresaEndPoint>()
                .MapEndPoint<GetAlunoByTreinamentoEndPoint>()
                .MapEndPoint<GetAllAlunoEndPoint>();

            endpoints.MapGroup("v1/certificados")
                .WithTags("certificados")
                .MapEndPoint<CreateCertificadoEndPoint>()
                .MapEndPoint<DeleteCertificadoEndPoint>()
                .MapEndPoint<GetAllCertificadosEndPoint>()
                .MapEndPoint<GetCertificadoByIdEndPoint>()
                .MapEndPoint<GetCertificadosByDateEndPoint>()
                .MapEndPoint<UpdateCertificadoEndPoint>();

            endpoints.MapGroup("v1/conteudo-programatico")
                .WithTags("conteudos-programatico")
                .MapEndPoint<CreateConteudoProgramaticoEndPoint>()
                .MapEndPoint<DeleteConteudoProgramaticoEndPoint>()
                .MapEndPoint<GetAllConteudoProgramaticoEndPoint>()
                .MapEndPoint<GetConteudoProgramaticoByCursoEndPoint>()
                .MapEndPoint<UpdateConteudoProgramaticoEndPoint>();

            endpoints.MapGroup("v1/cursos")
                .WithTags("cursos")
                .MapEndPoint<CreateCursoEndPoint>()
                .MapEndPoint<DeleteCursoEndPoint>()
                .MapEndPoint<GetAllCursosEndPoint>()
                .MapEndPoint<GetCursoByIdEndPoint>()
                .MapEndPoint<UpdateCursoEndPoint>();

            endpoints.MapGroup("v1/empresas")
                .WithTags("empresas")
                .MapEndPoint<CreateEmpresaEndPoint>()
                .MapEndPoint<DeleteEmpresaEndPoint>()
                .MapEndPoint<GetAllEmpresaEndPoint>()
                .MapEndPoint<GetEmpresaByIdEndPoint>()
                .MapEndPoint<UpdateEmpresaEndPoint>();

            endpoints.MapGroup("v1/enderecos-empresas")
                .WithTags("enderecos-empresas")
                .MapEndPoint<CreateEnderecoEmpresaEndPoint>()
                .MapEndPoint<DeleteEnderecoEmpresaEndPoint>()
                .MapEndPoint<GetEnderecoEmpresaByIdEndPoint>()
                .MapEndPoint<UpdateEnderecoEmpresaEndPoint>();

            endpoints.MapGroup("v1/instrutores")
                .WithTags("instrutores")
                .MapEndPoint<CreateInstrutorEndPoint>()
                .MapEndPoint<DeleteInstrutorEndPoint>()
                .MapEndPoint<GetAllInstrutorEndPoint>()
                .MapEndPoint<GetInstrutorByEspecializacaoEndPoint>()
                .MapEndPoint<GetInstrutorByIdEndPoint>()
                .MapEndPoint<GetInstrutorByTreinamentoEndPoint>()
                .MapEndPoint<UpdateInstrutorEndPoint>();

            endpoints.MapGroup("v1/listas-presenca")
                .WithTags("listas-presenca")
                .MapEndPoint<CreateListaPresencaEndPoint>()
                .MapEndPoint<DeleteListaPresencaEndPoint>()
                .MapEndPoint<GetAllListaPresencaEndPoint>()
                .MapEndPoint<GetListaPresencaByDateEndPoint>()
                .MapEndPoint<GetListaPresencaByIdEndPoint>()
                .MapEndPoint<UpdateListaPresencaEndPoint>();

            endpoints.MapGroup("v1/provas")
                .WithTags("provas")
                .MapEndPoint<CreateProvaEndPoint>()
                .MapEndPoint<DeleteProvaEndPoint>()
                .MapEndPoint<GetAllProvasEndPoint>()
                .MapEndPoint<GetProvaByIdEndPoint>()
                .MapEndPoint<GetProvasByCursoEndPoint>()
                .MapEndPoint<UpdateProvaEndPoint>();

            endpoints.MapGroup("v1/questoes")
                .WithTags("questoes")
                .MapEndPoint<CreateQuestaoEndPoint>()
                .MapEndPoint<DeleteQuestaoEndPoint>()
                .MapEndPoint<GetQuestaoByIdEndPoint>()
                .MapEndPoint<GetQuestaoByProvaEndPoint>()
                .MapEndPoint<UpdateQuestaoEndPoint>();

            endpoints.MapGroup("v1/telefone-empresas")
                .WithTags("telefone-empresas")
                .MapEndPoint<CreateTelefoneEmpresaEndPoint>()
                .MapEndPoint<DeleteTelefoneEmpresaEndPoint>()
                .MapEndPoint<GetTelefoneEmpresaByIdEndPoint>()
                .MapEndPoint<GetTelefoneByEmpresaEndPoint>()
                .MapEndPoint<UpdateTelefoneEmpresaEndPoint>();

            endpoints.MapGroup("v1/treinamentos")
               .WithTags("treinamentos")
               .MapEndPoint<CreateTreinamentoEndPoint>()
               .MapEndPoint<UpdateTreinamentoEndPoint>()
               .MapEndPoint<DeleteTreinamentoEndPoint>()
               .MapEndPoint<GetAllTreinamentoEndPoint>()
               .MapEndPoint<GetTreinamentoByDateEndPoint>()
               .MapEndPoint<GetTreinamentoByIdEndPoint>()
               .MapEndPoint<GetTreinamentoByAlunoEndPoint>()
               .MapEndPoint<GetTreinamentoByAlunoByDateEndPoint>()
               .MapEndPoint<GetTreinamentoByEmpresaEndPoint>()
               .MapEndPoint<GetTreinamentoByEmpresaByDateEndPoint>()
               .MapEndPoint<GetTreinamentoByInstrutorEndPoint>()
               .MapEndPoint<GetTreinamentoByInstrutorByDateEndPoint>()
               .MapEndPoint<GetTreinamentoBySituacaoEndPoint>();

            endpoints.MapGroup("v1/usuarios")
                .WithTags("usuarios")
                .MapEndPoint<CreateUsuarioEndPoint>()
                .MapEndPoint<DeleteUsuarioEndPoint>()
                .MapEndPoint<GetAllUsuarioEndPoint>()
                .MapEndPoint<GetByCredencialEndPoint>()
                .MapEndPoint<GetUsuarioByIdEndPoint>()
                .MapEndPoint<GetUsuarioAdminEndPoint>()
                .MapEndPoint<UpdateUsuarioEndPoint>();
        }

        private static IEndpointRouteBuilder MapEndPoint<TEndPoint>(this IEndpointRouteBuilder app)
            where TEndPoint : IEndPoint
        {
            TEndPoint.Map(app);
            return app;
        }
    }
}
