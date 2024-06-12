using Microsoft.AspNetCore.Components;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Instrutores;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Instrutores
{
    public partial class GetAllInstrutoresPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Instrutor> Instrutores { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public IInstrutorHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllInstrutorRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Instrutores = result.Dados ?? [];
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
        public async void OnDeleteButtonActive(Guid id, string Nome)
        {
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir o instrutor {Nome}", yesText: "Excluir", cancelText: "Cancelar");
        
            if(result is true)
                await OnDeleteAsync(id, Nome);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string Nome)
        {
            try
            {
                var request = new DeleteInstrutorRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Instrutores.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Instrutor {Nome} inativado", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Instrutor, bool> _quickFilter => x =>
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
        public async Task StartEditItem(Instrutor instrutor)
        {
            UpdateInstrutorRequest request = new UpdateInstrutorRequest
            {
                Id = instrutor.Id,
                Nome = instrutor.Nome,
                Cpf = instrutor.Cpf,
                Especializacao = instrutor.Especializacao,
                Registro = instrutor.Registro,
                Email = instrutor.Email,
                Telefone = instrutor.Telefone,
                Assinatura = instrutor.Assinatura,
                Status = instrutor.Status,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CanceledEditItem(Instrutor instrutor)
        {
            UpdateInstrutorRequest request = new UpdateInstrutorRequest
            {
                Id = instrutor.Id,
                Nome = instrutor.Nome,
                Cpf = instrutor.Cpf,
                Especializacao = instrutor.Especializacao,
                Registro = instrutor.Registro,
                Email = instrutor.Email,
                Telefone = instrutor.Telefone,
                Assinatura = instrutor.Assinatura,
                Status = instrutor.Status,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CommitedEditItem(Instrutor instrutor)
        {
            var request = new UpdateInstrutorRequest
            {
                Id = instrutor.Id,
                Nome = instrutor.Nome,
                Cpf = instrutor.Cpf,
                Especializacao = instrutor.Especializacao,
                Registro = instrutor.Registro,
                Email = instrutor.Email,
                Telefone = instrutor.Telefone,
                Assinatura = instrutor.Assinatura,
                Status = instrutor.Status,
            };
            var result = await Handler.UpdateAsync(request);

            Snackbar.Add(result.Message, Severity.Info);
        }
        #endregion

    }
}
