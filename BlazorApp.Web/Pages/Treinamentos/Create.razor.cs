using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Requests.Treinamentos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Treinamentos
{
    public partial class CreateTreinamentoPage : ComponentBase
    {
        #region Properties
        public CreateTreinamentoRequest InputModel { get; set; } = new();
        public string AlunoId { get; set; }
        public List<Guid> AlunosId { get; set; } = new();
        public string EmpresaId { get; set; }
        public List<Guid> EmpresasId { get; set; } = new();
        public string CursoId { get; set; }
        public string InstrutorId { get; set; }
        public List<Guid> InstrutoresId { get; set; } = new();
        public ETipoTreinamento tipoTreinamento { get; set; } = ETipoTreinamento.Inicial;
        public List<Empresa> Empresas { get; set; } = new();
        public List<Aluno> Alunos { get; set; } = new();
        public List<Curso> Cursos { get; set; } = new();
        public List<Instrutor> Instrutores { get; set; } = new();
        #endregion

        #region Services
        [Inject]
        public ITreinamentoHandler Handler { get; set; } = null!;
        [Inject]
        public IEmpresaHandler EmpresaHandler { get; set; } = null!;
        [Inject]
        public IAlunoHandler AlunoHandler { get; set; } = null!;
        [Inject]
        public ICursoHandler CursoHandler { get; set; } = null!;
        [Inject]
        public IInstrutorHandler InstrutorHandler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async void OnInitialized()
        {
            try
            {
                var request = new GetAllEmpresasRequest();
                var result = await EmpresaHandler.GetAllAsync(request);
                if (result.IsSuccess)
                    Empresas = result.Dados ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

            try
            {
                var request = new GetAllAlunoRequest();
                var result = await AlunoHandler.GetAllAsync(request);
                if (result.IsSuccess)
                    Alunos = result.Dados ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

            try
            {
                var request = new GetAllInstrutorRequest();
                var result = await InstrutorHandler.GetAllAsync(request);
                if (result.IsSuccess)
                    Instrutores = result.Dados ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

            try
            {
                var request = new GetAllCursosRequest();
                var result = await CursoHandler.GetAllAsync(request);
                if (result.IsSuccess)
                    Cursos = result.Dados ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            try
            {
                InputModel = new CreateTreinamentoRequest
                {
                    AlunosId = AlunosId,
                    CursoId = Guid.Parse(CursoId),
                    EmpresasId = EmpresasId,
                    InstrutoresId = InstrutoresId,
                    Situacao = ESituacaoTreinamento.Andamento,
                    Status = EAtivoInativo.Ativo,
                    Tipo = tipoTreinamento,
                    UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04")
                };

                var result = await Handler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/treinamentos");
                }
                else
                    Snackbar.Add(result.Message, Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async Task AddEmpresa()
        {
            try
            {
                if (!EmpresasId.Contains(Guid.Parse(EmpresaId)))
                {
                    EmpresasId.Add(Guid.Parse(EmpresaId));
                }
                else
                {
                    Snackbar.Add("Empresa já adicionada ao treinamento", Severity.Info);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async Task AddAluno()
        {
            try
            {
                if (!AlunosId.Contains(Guid.Parse(AlunoId)))
                {
                    AlunosId.Add(Guid.Parse(AlunoId));
                }
                else
                {
                    Snackbar.Add("Aluno já adicionada ao treinamento", Severity.Info);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            } 
        }

        public async Task AddInstrutor()
        {
            try
            {
                if (!InstrutoresId.Contains(Guid.Parse(InstrutorId)))
                {
                    InstrutoresId.Add(Guid.Parse(InstrutorId));
                }
                else
                {
                    Snackbar.Add("Instrutor já adicionado ao treinamento", Severity.Info);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        #endregion

    }
}
