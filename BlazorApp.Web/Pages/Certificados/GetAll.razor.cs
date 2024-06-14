using Microsoft.AspNetCore.Components;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Certificados;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Certificados
{
    public partial class GetAllCertificadosPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Certificado> Certificados { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public ICertificadoHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCertificadosRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Certificados = result.Dados ?? [];
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
        public async void OnDeleteButtonActive(Guid id, string Codigo)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir o certificado {Codigo}", yesText: "Excluir", cancelText: "Cancelar");
        
            if(result is true)
                await OnDeleteAsync(id, Codigo);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string Codigo)
        {
            try
            {
                var request = new DeleteCertificadoRequest()
                {
                    TreinamentoId = id
                };
                await Handler.DeleteAsync(request);
                Certificados.RemoveAll(x => x.TreinamentoId == id);
                Snackbar.Add($"Certificado {Codigo} inativado", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Certificado, bool> _quickFilter => x =>
        {
            if (x.Situacao == Shared.Enums.ESituacaoCertificado.Processando)
                return true;
            return false;
        };
        #region UpdateTable
        public bool _readOnly;
        public bool _isCellEditMode;
        public bool _editTriggerRowClick;
        #endregion
        public async Task StartEditItem(Certificado certificado)
        {
            UpdateCertificadoRequest request = new UpdateCertificadoRequest
            {
                TreinamentoId = certificado.TreinamentoId,
                Codigo = certificado.Codigo,
                DataInicioCertificado = certificado.DataInicioCertificado,
                DataAlteracao = certificado.DataAlteracao,
                Situacao = certificado.Situacao,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CanceledEditItem(Certificado certificado)
        {
            UpdateCertificadoRequest request = new UpdateCertificadoRequest
            {
                TreinamentoId = certificado.TreinamentoId,
                Codigo = certificado.Codigo,
                DataInicioCertificado = certificado.DataInicioCertificado,
                DataAlteracao = certificado.DataAlteracao,
                Situacao = certificado.Situacao,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CommitedEditItem(Certificado certificado)
        {
            var request = new UpdateCertificadoRequest
            {
                TreinamentoId = certificado.TreinamentoId,
                Codigo = certificado.Codigo,
                DataInicioCertificado = certificado.DataInicioCertificado,
                DataAlteracao = certificado.DataAlteracao,
                Situacao = certificado.Situacao,
            };
            var result = await Handler.UpdateAsync(request);

            Snackbar.Add(result.Message, Severity.Info);
        }
        #endregion
    }
}