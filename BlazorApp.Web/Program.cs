using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Web;
using MudBlazor.Services;
using BlazorApp.Shared;
using BlazorApp.Shared.Handlers;
using BlazorApp.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient(
    WebConfiguration.HttpClientName,
    opt => { opt.BaseAddress = new Uri(Configuration.BackendUrl);
    });

builder.Services.AddTransient<IEmpresaHandler, EmpresaHandler>();
builder.Services.AddTransient<IEnderecoEmpresaHandler, EnderecoEmpresaHandler>();
builder.Services.AddTransient<IAlunoHandler, AlunoHandler>();
builder.Services.AddTransient<IConteudoProgramaticoHandler, ConteudoProgramaticoHandler>();
builder.Services.AddTransient<IInstrutorHandler, InstrutorHandler>();
builder.Services.AddTransient<ICursoHandler, CursoHandler>();
builder.Services.AddTransient<ITelefoneEmpresaHandler, TelefoneEmpresaHandler>();
builder.Services.AddTransient<IProvaHandler, ProvaHandler>();
builder.Services.AddTransient<IQuestaoHandler, QuestaoHandler>();
builder.Services.AddTransient<IAlternativaHandler, AlternativaHandler>();
builder.Services.AddTransient<ITreinamentoHandler, TreinamentoHandler>();
builder.Services.AddTransient<ICertificadoHandler, CertificadoHandler>();
builder.Services.AddTransient<IUsuarioHandler, UsuarioHandler>();





await builder.Build().RunAsync();
