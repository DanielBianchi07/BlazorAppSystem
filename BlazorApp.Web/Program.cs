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

await builder.Build().RunAsync();
