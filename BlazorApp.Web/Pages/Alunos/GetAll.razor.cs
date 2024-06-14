using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Alunos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Alunos
{
    public partial class GetAllAlunosPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Aluno> Alunos { get; set; } = [];
        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService Dialog { get; set; } = null!;
        [Inject]
        public IAlunoHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllAlunoRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Alunos = result.Dados ?? [];
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
            var result = await Dialog.ShowMessageBox("CUIDADO!", $"Tem certeza que deseja excluir o aluno {nome}?", yesText: "Excluir", cancelText: "Cancelar");
        
            if(result is true)
                await OnDeleteAsync(id, nome);
            StateHasChanged();
        }

        public async Task OnDeleteAsync(Guid id, string nome)
        {
            try
            {
                var request = new DeleteAlunoRequest()
                {
                    Id = id,
                };
                await Handler.DeleteAsync(request);
                Alunos.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Aluno {nome} inativo", Severity.Info);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public Func<Aluno, bool> _quickFilter => x =>              
        {
            if (x.Status == Shared.Enums.EAtivoInativo.Ativo)
                return true;
            return false;
        };
        #endregion
    }
}
