using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Requests.Usuarios;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Usuarios
{
    public partial class CreateUsuarioPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateUsuarioRequest InputModel { get; set; } = new();

        #endregion

        #region Services
        [Inject]
        public IUsuarioHandler Handler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/");
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
        #endregion
    }
}
