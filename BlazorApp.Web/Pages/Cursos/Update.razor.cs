using BlazorApp.Shared.Common;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Web.Pages.Cursos
{
    public partial class UpdateCursoPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        [Parameter]
        public string Id { get; set; } = string.Empty;
        public UpdateCursoRequest InputModel { get; set; }
        public UpdateConteudoProgramaticoRequest ConteudoInputModel { get; set; }
        public List<ConteudoProgramatico> Conteudos { get; set; } = new();
        public string Subject { get; set; }
        public string HourQuantity { get; set; }

        #endregion

        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ICursoHandler CursoHandler { get; set; } = null!;
        [Inject]
        public IConteudoProgramaticoHandler ConteudoHandler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            InputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            ConteudoInputModel.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            GetCursoByIdRequest? request = null;
            GetConteudoProgramaticoByCursoRequest? requestcont = null;
            try
            {
                request = new GetCursoByIdRequest { Id = Guid.Parse(Id) };
                requestcont = new GetConteudoProgramaticoByCursoRequest { CursoId = Guid.Parse(Id) };
            }
            catch
            {
                Snackbar.Add("Parâmetro Inválido");
            }

            try
            {
                var response = await CursoHandler.GetByIdAsync(request);
                var responsecont = await ConteudoHandler.GetByCursoAsync(requestcont);

                if (response is { IsSuccess: true, Dados: not null } && responsecont is { IsSuccess: true, Dados: not null })
                {
                    InputModel = new UpdateCursoRequest
                    {
                        Id = response.Dados.Id,
                        Nome = response.Dados.Nome,
                        Logo = response.Dados.Logo,
                        CargaHorariaInicial = response.Dados.CargaHorariaInicial,
                        CargaHorariaPeriodico = response.Dados.CargaHorariaPeriodico,
                        Validade = response.Dados.Validade,
                        Status = response.Dados.Status
                    };

                    Conteudos = responsecont.Dados?.Where(e => e.Status == Shared.Enums.EAtivoInativo.Ativo).ToList() ?? new List<ConteudoProgramatico>();

                    foreach (var cont in Conteudos)
                    {
                        ConteudoInputModel = new UpdateConteudoProgramaticoRequest
                        {
                            CursoId = cont.CursoId,
                            Assunto = cont.Assunto,
                            CargaHoraria = cont.CargaHoraria
                        };
                    }
                    
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
                var result = await CursoHandler.UpdateAsync(InputModel);
                var resultcont = await ConteudoHandler.UpdateAsync(ConteudoInputModel);
                if (result is { IsSuccess: true } && resultcont is { IsSuccess: true })
                {
                    Snackbar.Add("Curso atualizado", Severity.Success);
                    NavigationManager.NavigateTo("/cursos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
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