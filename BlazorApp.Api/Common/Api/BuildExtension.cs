﻿using BlazorApp.Api.Data;
using BlazorApp.Api.Handlers;
using BlazorApp.Shared;
using BlazorApp.Shared.Handlers;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Common.Api
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => 
            { 
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>(x => { x.UseSqlServer(ApiConfiguration.ConnectionString); });
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy.WithOrigins([
                    Configuration.BackendUrl,
                    Configuration.FrontendUrl
                    ])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAlternativaHandler, AlternativaHandler>();
            builder.Services.AddTransient<IAlunoHandler, AlunoHandler>();
            builder.Services.AddTransient<ICertificadoHandler, CertificadoHandler>();
            builder.Services.AddTransient<IConteudoProgramaticoHandler, ConteudoProgramaticoHandler>();
            builder.Services.AddTransient<ICursoHandler, CursoHandler>();
            builder.Services.AddTransient<IEmpresaHandler, EmpresaHandler>();
            builder.Services.AddTransient<IEnderecoEmpresaHandler, EnderecoEmpresaHandler>();
            builder.Services.AddTransient<IInstrutorHandler, InstrutorHandler>();
            builder.Services.AddTransient<IListaPresencaHandler, listaPresencaHandler>();
            builder.Services.AddTransient<IProvaHandler, ProvaHandler>();
            builder.Services.AddTransient<IQuestaoHandler, QuestaoHandler>();
        }
    }
}