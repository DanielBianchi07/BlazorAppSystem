using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Requests.Empresas;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Alunos
{
    public partial class CreateAlunoPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateAlunoRequest InputModel { get; set; } = new();
        public string SelectedEmpresaId { get; set; } = string.Empty;
        public List<Empresa> TodasEmpresas { get; set; } = new();
        public string SelectedOption { get; set; } = "Celular";
        public string Telefone { get; set; }
        public string Celular { get; set; }
       

        #endregion

        #region Services
        [Inject]
        public IAlunoHandler AlunoHandler { get; set; } = null!;
        [Inject]
        public IEmpresaHandler EmpresaHandler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            InputModel.EmpresaId = Guid.Parse(SelectedEmpresaId);
            InputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            try
            {
                var result = await AlunoHandler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/alunos");
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

        protected override async Task OnInitializedAsync()
        {
            var response = await EmpresaHandler.GetAllAsync(new GetAllEmpresasRequest());
            if (response.IsSuccess)
            {
                TodasEmpresas = response.Dados?.Where(e => e.Status == Shared.Enums.EAtivoInativo.Ativo).ToList() ?? new List<Empresa>();
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }

        #endregion
    }
}
