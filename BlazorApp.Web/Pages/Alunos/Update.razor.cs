using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.Alunos;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Web.Pages.Alunos
{
    public partial class UpdateAlunoPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        [Parameter]
        public string Id { get; set; } = string.Empty;
        public UpdateAlunoRequest? InputModel { get; set; }
        public List<Empresa> TodasEmpresas { get; set; } = new();

        public string SelectedEmpresaId { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IAlunoHandler AlunoHandler { get; set; } = null!;
        [Inject]
        public IEmpresaHandler EmpresaHandler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            InputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            var responsend = await EmpresaHandler.GetAllAsync(new GetAllEmpresasRequest());
            if (responsend.IsSuccess)
            {
                TodasEmpresas = responsend.Dados?.Where(e => e.Status == Shared.Enums.EAtivoInativo.Ativo).ToList() ?? new List<Empresa>();
            }
            else
            {
                Snackbar.Add(responsend.Message, Severity.Error);
            }

            if (string.IsNullOrEmpty(Id))
            {
                Snackbar.Add("Parâmetro Inválido", Severity.Error);
                return;
            }

            try
            {
                var request = new GetAlunoByIdRequest { Id = Guid.Parse(Id) };
                var response = await AlunoHandler.GetByIdAsync(request);

                if (response.IsSuccess && response.Dados != null)
                {
                    var aluno = response.Dados;

                    // Encontrar a empresa associada ao aluno
                    var empresaAssociada = TodasEmpresas.FirstOrDefault(e => e.Id == Guid.Parse(SelectedEmpresaId));

                    if (empresaAssociada != null)
                    {
                        SelectedEmpresaId = empresaAssociada.Id.ToString();

                        InputModel = new UpdateAlunoRequest
                        {
                            Id = aluno.Id,
                            Nome = aluno.Nome,
                            Cpf = aluno.Cpf,
                            Rg = aluno.Rg,
                            Email = aluno.Email,
                            Telefone = aluno.Telefone,
                            Assinatura = aluno.Assinatura,
                            EmpresaId = Guid.Parse(SelectedEmpresaId)
                        };
                    }
                    else
                    {
                        Snackbar.Add("Empresa associada não encontrada para o aluno.", Severity.Warning);
                    }
                }
                else
                {
                    Snackbar.Add("Aluno não encontrado", Severity.Error);
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
                var result = await AlunoHandler.UpdateAsync(InputModel);
                if (result is { IsSuccess: true })
                {
                    Snackbar.Add("Aluno atualizadao", Severity.Success);
                    NavigationManager.NavigateTo("/alunos");
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