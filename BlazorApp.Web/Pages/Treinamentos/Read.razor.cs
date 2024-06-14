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
    public partial class ReadTreinamentoPage : ComponentBase
    {
        #region Properties
        public Treinamento Treinamento { get; set; } = new Treinamento();
        [Parameter]
        public string Id { get; set; }
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public ITreinamentoHandler Handler { get; set; } = null!;
        [Inject]
        public ICursoHandler CursoHandler { get; set; } = null!;
        [Inject]
        public IEmpresaHandler EmpresaHandler { get; set; } = null!;
        [Inject]
        public IAlunoHandler AlunoHandler { get; set; } = null!;
        [Inject]
        public IInstrutorHandler InstrutorHandler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var request = new GetTreinamentoByIdRequest { Id = Guid.Parse(Id) };
                var result = await Handler.GetByIdAsync(request);
                if (result.IsSuccess)
                {
                    Treinamento = result.Dados;

                    // Load Curso details
                    var requestcurso = new GetCursoByIdRequest { Id = Treinamento.CursoId };
                    var resultcurso = await CursoHandler.GetByIdAsync(requestcurso);
                    if (resultcurso.IsSuccess)
                    {
                        Treinamento.Curso = resultcurso.Dados;
                    }

                    // Load Empresas details
                    foreach (var empId in Treinamento.Empresas)
                    {
                        var requestempresa = new GetEmpresaByIdRequest { Id = empId.Id };
                        var resultempresa = await EmpresaHandler.GetByIdAsync(requestempresa);
                        if (resultempresa.IsSuccess)
                        {
                            Treinamento.Empresas.Add(resultempresa.Dados);
                        }
                    }

                    // Load Alunos details
                    foreach (var alunoId in Treinamento.Alunos)
                    {
                        var requestaluno = new GetAlunoByIdRequest { Id = alunoId.Id };
                        var resultaluno = await AlunoHandler.GetByIdAsync(requestaluno);
                        if (resultaluno.IsSuccess)
                        {
                            Treinamento.Alunos.Add(resultaluno.Dados);
                        }
                    }

                    // Load Instrutores details
                    foreach (var instrutorId in Treinamento.Instrutores)
                    {
                        var requestinstrutor = new GetInstrutorByIdRequest { Id = instrutorId.Id };
                        var resultinstrutor = await InstrutorHandler.GetByIdAsync(requestinstrutor);
                        if (resultinstrutor.IsSuccess)
                        {
                            Treinamento.Instrutores.Add(resultinstrutor.Dados);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        #endregion

        public void BackToList()
        {
            NavigationManager.NavigateTo("/treinamentos");
        }
    }
}
