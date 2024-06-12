using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Empresas;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Empresas
{
    public partial class GetAllEmpresasPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Empresa> Empresas { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public IEmpresaHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllEmpresasRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Empresas = result.Dados ?? [];
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
        public async void OnDeleteButtonActive(Guid id, string razao)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir a empresa {razao}", yesText: "Excluir", cancelText: "Cancelar");
        
            if(result is true)
                await OnDeleteAsync(id, razao);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string razao)
        {
            try
            {
                var request = new DeleteEmpresaRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Empresas.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Empresa {razao} inativada", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Empresa, bool> _quickFilter => x =>
        {
            if (x.Status == Shared.Enums.EAtivoInativo.Ativo)
                return true;
            return false;
        };
        #endregion
    }
}
