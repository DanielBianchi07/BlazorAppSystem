using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Instrutores;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Instrutores
{
    public partial class UpdateInstrutorPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        [Parameter]
        public string Id { get; set; } = string.Empty;
        public UpdateInstrutorRequest InputModel { get; set; }

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IInstrutorHandler Handler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            GetInstrutorByIdRequest? request = null;
            try
            {
                request = new GetInstrutorByIdRequest { Id = Guid.Parse(Id) };
            }
            catch
            {
                Snackbar.Add("Parâmetro Inválido");
            }

            if (request is null)
                return;

            try
            {
                var response = await Handler.GetByIdAsync(request);

                if (response is { IsSuccess: true, Dados: not null } )
                {
                    InputModel = new UpdateInstrutorRequest
                    {
                        Id = response.Dados.Id,
                        Nome = response.Dados.Nome,
                        Cpf = response.Dados.Cpf,
                        Email = response.Dados.Email,
                        Telefone = response.Dados.Telefone,
                        Especializacao = response.Dados.Especializacao,
                        Registro = response.Dados.Registro,
                        Assinatura = response.Dados.Assinatura,
                        Status = response.Dados.Status
                    };
                }
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
                var result = await Handler.UpdateAsync(InputModel);
                if (result is { IsSuccess: true })
                {
                    Snackbar.Add("Instrutor atualizado", Severity.Success);
                    NavigationManager.NavigateTo("/instrutores");
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