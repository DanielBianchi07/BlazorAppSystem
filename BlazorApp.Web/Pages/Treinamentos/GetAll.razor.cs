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
    public partial class GetAllTreinamentoPage : ComponentBase
    {
        #region Properties
        public List<Treinamento> Treinamentos { get; set; } = [];
        public List<Empresa> Empresas { get; set; } = [];
        public List<Aluno> Alunos { get; set; } = [];
        public List<Instrutor> Instrutores { get; set; } = [];
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
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            
            try
            {
                var request = new GetAllTreinamentosRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Treinamentos = result.Dados ?? [];
 
                foreach(var tr in Treinamentos)
                {
                    var requestcurso = new GetCursoByIdRequest { Id = tr.CursoId };
                    var resultcurso = await CursoHandler.GetByIdAsync(requestcurso);

                    if (resultcurso.IsSuccess)
                        tr.Curso = resultcurso.Dados;
                }

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        #endregion

        #region Methods
        public async void OnDeleteButtonActive(Guid id, string curso, DateTime? data)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir o treinamento de {curso} na data: {data}", yesText: "Excluir", cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, curso, data);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string curso, DateTime? data)
        {
            try
            {
                var request = new DeleteTreinamentoRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Treinamentos.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Treinamento de {curso} em {data} inativada", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Treinamento, bool> _quickFilter => x =>
        {
            if (x.Status == Shared.Enums.EAtivoInativo.Ativo)
                return true;
            return false;
        };
        #endregion
    }
}
