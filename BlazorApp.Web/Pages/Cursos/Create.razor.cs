using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Cursos
{
    public partial class CreateCursoPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateCursoRequest InputModel { get; set; } = new();
        public CreateConteudoProgramaticoRequest InputModelConteudo { get; set; } = new();
        public List<ConteudoProgramatico> Conteudos { get; set; } = new();
        public string Subject { get; set; }
        public string HourQuantity { get; set; }

        #endregion

        #region Services
        [Inject]
        public ICursoHandler Handler { get; set; } = null!;
        [Inject]
        public IConteudoProgramaticoHandler ConteudoHandler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            InputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            try
            {
                var result = await Handler.CreateAsync(InputModel);

                if (result.IsSuccess)
                {
                    if (result.IsSuccess)
                    {
                        foreach (var conteudo in Conteudos)
                        {
                            InputModelConteudo.CursoId = result.Dados.Id;
                            InputModelConteudo.Assunto = conteudo.Assunto;
                            InputModelConteudo.CargaHoraria = conteudo.CargaHoraria;
                            InputModelConteudo.Status = conteudo.Status;

                            await ConteudoHandler.CreateAsync(InputModelConteudo);
                        }
                        Snackbar.Add(result.Message, Severity.Success);
                        NavigationManager.NavigateTo("/cursos");
                    }
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

        public void AddConteudo()
        {
            if (!string.IsNullOrEmpty(Subject) && int.TryParse(HourQuantity, out int hourQuantity) && hourQuantity > 0)
            {
                if (!Conteudos.Any(c => c.Assunto == Subject))
                {
                    Conteudos.Add(new ConteudoProgramatico { Assunto = Subject, CargaHoraria = hourQuantity });
                }
                else
                {
                    Snackbar.Add("Conteúdo com o mesmo assunto já existe.", Severity.Warning);
                }
            }
            else
            {
                Snackbar.Add("Preencha todos os campos corretamente.", Severity.Error);
            }
        }
        #endregion
    }
}
