using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Colors;

namespace BlazorApp.Web.Pages.Empresas
{
    public partial class CreateEmpresaPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateEmpresaRequest InputModel { get; set; } = new();
        public CreateTelefoneEmpresaRequest InputModelTelefone { get; set; } = new();
        public string Telefone { get; set; } = string.Empty;

        public Dictionary<string, List<string>> EstadosCidades = ConstantStatesAndCities.dicionario;
        #endregion

        #region Services
        [Inject]
        public IEmpresaHandler Handler { get; set; } = null!;
        [Inject]
        public ITelefoneEmpresaHandler TelefoneHandler { get; set; } = null!;
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
                    foreach(var tel in InputModel.Telefones)
                    {
                        tel.EmpresaId = result.Dados.Id;
                        InputModelTelefone.NroTelefone = tel.NroTelefone;
                        InputModelTelefone.EmpresaId = tel.EmpresaId;
                        InputModelTelefone.Status = tel.Status;

                        TelefoneHandler.CreateAsync(InputModelTelefone);
                    }

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

        public void AddTelefone()
        {
            if (!string.IsNullOrEmpty(Telefone))
            {
                if (!InputModel.Telefones.Any(c => c.NroTelefone == Telefone))
                {
                    InputModel.Telefones.Add(new TelefoneEmpresa { NroTelefone = Telefone, Status = Shared.Enums.EAtivoInativo.Ativo });
                }
                else
                {
                    Snackbar.Add("Telefone com o mesmo número já existe.", Severity.Warning);
                }
            }
            else
            {
                Snackbar.Add("Preencha todos os campos corretamente.", Severity.Error);
            }
        }
        protected override void OnInitialized()
        {
            InputModel.Endereco = new();
            InputModel.Telefones = new();
        }
        #endregion
    }
}
