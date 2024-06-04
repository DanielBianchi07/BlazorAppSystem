using BlazorApp.Api;
using BlazorApp.Api.Common.Api;
using BlazorApp.Api.Data;
using BlazorApp.Api.EndPoints;
using BlazorApp.Api.Handlers;
using BlazorApp.Shared.Handlers;
var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndPoints();

app.Run();
