﻿using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Web.Pages.Empresas
{
    public partial class CreateAlunoPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateAlunoRequest InputModel { get; set; } = new();
        public string StringEmpresa { get; set; } = string.Empty;
        public List<Empresa> EmpresasFilter { get; set; } = new();
        public CancellationTokenSource? cancellationTokenSource;
        // public CreateTelefoneEmpresaRequest InputModelTelefone { get; set; } = new();
        // public string Telefone { get; set; } = string.Empty;

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
            foreach (var empresa in EmpresasFilter)
            {
                if (empresa.RazaoSocial == StringEmpresa)
                {
                    InputModel.EmpresaId = empresa.Id;
                    break;
                }
            }

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
            cancellationTokenSource = new CancellationTokenSource();
            await LoadEmpresas();
        }

        protected async Task LoadEmpresas()
        {
            var response = await EmpresaHandler.GetAllAsync(new GetAllEmpresasRequest());
            if (response.IsSuccess)
            {
                EmpresasFilter = response.Dados ?? new List<Empresa>();
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }

        public async Task SearchEmpresas(ChangeEventArgs e)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();

            var searchTerm = e.Value?.ToString().Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                await LoadEmpresas();
                return;
            }

            var getEmpresasTask = EmpresaHandler.GetByRazaoSocial(new GetEmpresaByRazaoSocialRequest { RazaoSocial = searchTerm });
            var completedTask = await Task.WhenAny(getEmpresasTask, Task.Delay(Timeout.Infinite, cancellationTokenSource.Token));

            if (completedTask == getEmpresasTask)
            {
                var response = await getEmpresasTask;
                EmpresasFilter = response.Dados ?? new List<Empresa>();
            }
            else
            {
                Snackbar.Add("Erro", Severity.Error);
            }
        }

        public void HandleIntervalElapsed(string debouncedText)
        {
            // at this stage, interval has elapsed
        }
        //public async Task SearchEmpresas(ChangeEventArgs e)
        //{
        //    var emp = new GetEmpresaByRazaoSocialRequest
        //    {
        //        RazaoSocial = StringEmpresa
        //    };
        //    StringEmpresa = e.Value.ToString();
        //    var request = await EmpresaHandler.GetByRazaoSocial(emp);
        //    EmpresasFilter = request.Dados;
        //}

        //public void SelectEmpresa(Empresa empresa)
        //{
        //    InputModel.EmpresaId = empresa.Id;
        //    StringEmpresa = empresa.RazaoSocial;
        //    EmpresasFilter.Clear();
        //}

        #endregion
    }
}