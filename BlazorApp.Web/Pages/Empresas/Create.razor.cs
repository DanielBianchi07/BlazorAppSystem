using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Empresas
{
    public partial class CreateEmpresaPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateEmpresaRequest InputModel { get; set; } = new();

        public Dictionary<string, List<string>> EstadosCidades = ConstantStatesAndCities.dicionario;
        #endregion

        #region Services
        [Inject]
        public IEmpresaHandler Handler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            InputModel.Endereco.CreatedBy = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            InputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            try
            {
                var result = await Handler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/empresas");
                }
                else
                {
                    Snackbar.Add(result.Message, Severity.Error);
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

        protected override void OnInitialized()
        {
            InputModel.Endereco = new();
        }
        #endregion
    }
}
