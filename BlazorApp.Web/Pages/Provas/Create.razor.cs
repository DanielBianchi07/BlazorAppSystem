using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Requests.Cursos;
using Microsoft.AspNetCore.Components;
using BlazorApp.Shared.Enums;
using MudBlazor;

namespace BlazorApp.Web.Pages.Provas
{
    public partial class CreateProvaPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateProvaRequest InputModel { get; set; } = new();
        public CreateQuestaoRequest InputModelQuestao { get; set; } = new();
        public CreateAlternativaRequest InputModelAlternativa { get; set; } = new();
        public List<Questao> Questoes { get; set; } = new();
        public List<Alternativa> Alternativas { get; set; } = new();
        public Curso Curso { get; set; } = new();
        public string cursoId { get; set; } = "";
        public List<Curso> Cursos { get; set; } = new();
        public string Questao { get; set; } = string.Empty;
        public string Alternativa { get; set; } = string.Empty;
        public ERespostaAlternativa Resposta { get; set; }

        #endregion

        #region Services
        [Inject]
        public IProvaHandler Handler { get; set; } = null!;
        [Inject]
        public IQuestaoHandler QuestaoHandler { get; set; } = null!;
        [Inject]
        public IAlternativaHandler AlternativaHandler { get; set; } = null!;
        [Inject]
        public ICursoHandler CursoHandler { get; set; } = null!;
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
            InputModelQuestao.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
            InputModel.CursoId = Guid.Parse(cursoId);

            try
            {
                var result = await Handler.CreateAsync(InputModel);


                if (result.IsSuccess)
                {
                    try
                    {

                        foreach (var quest in Questoes)
                        {
                            InputModelQuestao.ProvaId = result.Dados.Id;
                            InputModelQuestao.Conteudo = quest.Conteudo;
                            //InputModelQuestao.Status = quest.Status;

                            // await QuestaoHandler.CreateAsync(InputModelQuestao);
                            var result1 = await QuestaoHandler.CreateAsync(InputModelQuestao);

                            //Agora vamos cadastrar as alternativas em cada questão
                            if (result1.IsSuccess)
                            {
                                try
                                {

                                    foreach (var alt in Alternativas)
                                    {
                                        //if (alt.QuestaoId == result1.Dados.Id)
                                        //{
                                        InputModelAlternativa.QuestaoId = alt.QuestaoId;
                                        InputModelAlternativa.Conteudo = alt.Conteudo;
                                        InputModelAlternativa.Resposta = alt.Resposta;
                                        //InputModelAlternativa.Status = alt.Status;
                                        InputModelAlternativa.UsuarioId = new Guid("23D56E63-0795-422A-9133-07113575BF04");
                                        //}

                                        var result2 = await AlternativaHandler.CreateAsync(InputModelAlternativa);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Snackbar.Add(ex.Message, Severity.Error);
                                }

                            }
                            else
                            {
                                Snackbar.Add(result1.Message, Severity.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Snackbar.Add(ex.Message, Severity.Error);
                    }

                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/provas");
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

        public void AddQuestao()
        {
            if (!string.IsNullOrEmpty(Questao))
            {
                if (!Questoes.Any(q => q.Conteudo == Questao))
                {
                    Questoes.Add(new Questao { Conteudo = Questao});
                    Questao = string.Empty;
                }
                else
                {
                    Snackbar.Add("Essa questão já existe.", Severity.Warning);
                }
            }
            else
            {
                Snackbar.Add("Preencha todos os campos corretamente.", Severity.Error);
            }

           
        }
        public void AddAlternativa(Guid questaoId)
        {
            if (!string.IsNullOrEmpty(Alternativa))
            {
                var questao = Questoes.FirstOrDefault(q => q.Id == questaoId);

                if (Alternativas != null && !string.IsNullOrEmpty(Alternativa))
                {
                    if (Alternativas == null)
                    {
                        Alternativas = new List<Alternativa>();
                    }
                    if (!Alternativas.Any(a => a.Conteudo == Alternativa) && questao.Id == questaoId)
                    {
                        Alternativas.Add(new Alternativa
                        {
                            Conteudo = Alternativa,
                            Resposta = Resposta,
                            QuestaoId = questaoId
                        });
                        Alternativa = string.Empty; // Limpar o campo após adicionar
                        Resposta = ERespostaAlternativa.Errada; // Resetar o valor da checkbox após adicionar
                    }
                    else
                    {
                        Snackbar.Add("Essa alternativa já existe.", Severity.Warning);
                    }
                }
                else
                {
                    Snackbar.Add("Preencha todos os campos corretamente.", Severity.Error);
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            var response = await CursoHandler.GetAllAsync(new GetAllCursosRequest());
            if (response.IsSuccess)
            {
                Cursos = response.Dados?.Where(e => e.Status == Shared.Enums.EAtivoInativo.Ativo).ToList() ?? new List<Curso>();
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
            
        }
        #endregion
    }
}
