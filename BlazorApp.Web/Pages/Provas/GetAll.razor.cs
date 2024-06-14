using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Requests.Cursos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Provas
{
    public partial class GetAllProvaPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Prova> Provas { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public IProvaHandler Handler { get; set; } = null!;
        [Inject]
        public ICursoHandler CursoHandler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllProvasRequest();
                var result = await Handler.GetAllAsync(request);
                //
                if (result.IsSuccess)
                    Provas = result.Dados ?? [];
                foreach (var prova in Provas)
                {
                    var requestcur = new GetCursoByIdRequest { Id = prova.CursoId};
                    var resultcur = await CursoHandler.GetByIdAsync(requestcur);

                    if (resultcur.IsSuccess)
                        prova.Curso = resultcur.Dados;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

        #region Methods
        public async void OnDeleteButtonActive(Guid id, string curso)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir a prova referente ao curso {curso}", yesText: "Excluir", cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, curso);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string curso)
        {
            try
            {
                var request = new DeleteProvaRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Provas.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Prova de {curso} inativada", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Prova, bool> _quickFilter => x =>
        {
            if (x.Status == Shared.Enums.EAtivoInativo.Ativo)
                return true;
            return false;
        };
        #endregion

    }
}