using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Cursos
{
    public partial class GetAllCursosPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Curso> Cursos { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public ICursoHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCursosRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Cursos = result.Dados ?? [];
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
        public async void OnDeleteButtonActive(Guid id, string nome)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir o curso {nome}", yesText: "Excluir", cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, nome);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string nome)
        {
            try
            {
                var request = new DeleteCursoRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Cursos.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Curso {nome} inativado", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Curso, bool> _quickFilter => x =>
        {
            if (x.Status == Shared.Enums.EAtivoInativo.Ativo)
                return true;
            return false;
        };
        #region UpdateTable
        public bool _readOnly;
        public bool _isCellEditMode;
        public bool _editTriggerRowClick;
        #endregion
        public async Task StartEditItem(Curso curso)
        {
            UpdateCursoRequest request = new UpdateCursoRequest
            {
                Id = curso.Id,
                Logo = curso.Logo,
                CargaHorariaInicial = curso.CargaHorariaInicial,
                CargaHorariaPeriodico= curso.CargaHorariaPeriodico,
                Validade = curso.Validade,
                Status = curso.Status,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CanceledEditItem(Curso curso)
        {
            UpdateCursoRequest request = new UpdateCursoRequest
            {
                Id = curso.Id,
                Logo = curso.Logo,
                CargaHorariaInicial = curso.CargaHorariaInicial,
                CargaHorariaPeriodico = curso.CargaHorariaPeriodico,
                Validade = curso.Validade,
                Status = curso.Status,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CommitedEditItem(Curso curso)
        {
            var request = new UpdateCursoRequest
            {
                Id = curso.Id,
                Logo = curso.Logo,
                CargaHorariaInicial = curso.CargaHorariaInicial,
                CargaHorariaPeriodico = curso.CargaHorariaPeriodico,
                Validade = curso.Validade,
                Status = curso.Status,
            };
            var result = await Handler.UpdateAsync(request);

            Snackbar.Add(result.Message, Severity.Info);
        }
        #endregion

    }
}
