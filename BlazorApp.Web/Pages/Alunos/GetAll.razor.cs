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
        #region UpdateTable
        public bool _readOnly;
        public bool _isCellEditMode;
        public bool _editTriggerRowClick;
        #endregion
        public async Task StartEditItem(Aluno aluno)
        {
            UpdateAlunoRequest request = new UpdateAlunoRequest
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Rg = aluno.Rg,
                Telefone = aluno.Telefone,
                Email = aluno.Email,
                Assinatura = aluno.Assinatura,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CanceledEditItem(Aluno aluno)
        {
            UpdateAlunoRequest request = new UpdateAlunoRequest
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Rg = aluno.Rg,
                Telefone = aluno.Telefone,
                Email = aluno.Email,
                Assinatura = aluno.Assinatura,
            };
            var result = await Handler.UpdateAsync(request);
        }

        public async Task CommitedEditItem(Aluno aluno)
        {
            var request = new UpdateAlunoRequest
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                Rg = aluno.Rg,
                Telefone = aluno.Telefone,
                Email = aluno.Email,
                Assinatura = aluno.Assinatura,
            };
            var result = await Handler.UpdateAsync(request);

            Snackbar.Add(result.Message, Severity.Info);
        }
        #endregion

    }
}
