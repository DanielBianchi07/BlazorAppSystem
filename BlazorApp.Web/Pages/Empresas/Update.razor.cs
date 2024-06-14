using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Empresas
{
    public partial class UpdateEmpresaPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        [Parameter]
        public string Id { get; set; } = string.Empty;
        public UpdateEmpresaRequest InputModel { get; set; }
        public UpdateEnderecoEmpresaRequest InputEnderecoModel { get; set; }
        public UpdateTelefoneEmpresaRequest InputTelefoneModel { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public List<TelefoneEmpresa> telefoneEmpresas { get; set; } = new();
        public Dictionary<string, List<string>> EstadosCidades = ConstantStatesAndCities.dicionario;

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IEmpresaHandler Handler { get; set; } = null!;
        [Inject]
        public ITelefoneEmpresaHandler TelefoneHandler { get; set; } = null!;
        [Inject]
        public IEnderecoEmpresaHandler EnderecoHandler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            GetEmpresaByIdRequest? request = null;
            GetEnderecoEmpresaByIdRequest? requestend = null;
            GetTelefonesByEmpresasRequest? requesttel = null;
            try
            {
                request = new GetEmpresaByIdRequest{ Id = Guid.Parse(Id) };
                requestend = new GetEnderecoEmpresaByIdRequest { EmpresaId = Guid.Parse(Id) };
                requesttel = new GetTelefonesByEmpresasRequest { EmpresaId= Guid.Parse(Id) };

            }
            catch
            {
                Snackbar.Add("Parâmetro Inválido");
            }

            if (request is null)
                return;

            try
            {
                var responseend = await EnderecoHandler.GetByIdAsync(requestend);
                var response = await Handler.GetByIdAsync(request);
                var responsetel = await TelefoneHandler.GetByEmpresaAsync(requesttel);

                if (response is { IsSuccess: true, Dados: not null } &&  responseend is { IsSuccess: true, Dados: not null })
                {
                    InputModel = new UpdateEmpresaRequest
                    {
                        Id = response.Dados.Id,
                        RazaoSocial = response.Dados.RazaoSocial,
                        CNPJ = response.Dados.CNPJ,
                        Status = response.Dados.Status,
                        Email = response.Dados.Email,
                        Endereco = responseend.Dados,
                        Telefones = responsetel.Dados
                    };

                    InputEnderecoModel = new UpdateEnderecoEmpresaRequest
                    {
                        Bairro = responseend.Dados.Bairro,
                        CEP = responseend.Dados.CEP,
                        Cidade = responseend.Dados.Cidade,
                        Complemento = responseend.Dados.Complemento,
                        Estado = responseend.Dados.Estado,
                        NomeRua = responseend.Dados.NomeRua,
                        Numero = responseend.Dados.Numero,
                        Status = responseend.Dados.Status,
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
                var resultend = await EnderecoHandler.UpdateAsync(InputEnderecoModel);
                if (result is { IsSuccess: true } && resultend is { IsSuccess: true})
                {
                    Snackbar.Add("Empresa atualizada", Severity.Success);
                    NavigationManager.NavigateTo("/empresas");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void AddTelefone()
        {

        }

        #endregion
    }
}