using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Usuarios
{
    public partial class LoginUsuarioPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public GetUsuarioBySenhaEmailRequest InputModel { get; set; } = new();

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IUsuarioHandler Handler { get; set; } = null!;
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            try
            {
                var result = await Handler.GetByCredenciais(InputModel);
                if (result is { IsSuccess: true })
                {
                    Snackbar.Add("Logado!", Severity.Success);
                    NavigationManager.NavigateTo("/HomePage");
                }
                else
                {
                    Snackbar.Add("Credenciais Invalidas!", Severity.Warning);
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
