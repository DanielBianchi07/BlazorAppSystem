using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IProvaHandler
    {
        Task<Response<Prova?>> CreateAsync(CreateProvaRequest request);
        Task<Response<Prova?>> DeleteAsync(DeleteProvaRequest request);
        Task<PagedResponse<List<Prova>?>> GetAllAsync(GetAllProvasRequest request);
        Task<PagedResponse<List<Prova>?>> GetByCursoAsync(GetProvaByCursoRequest request);
        Task<Response<Prova?>> GetByIdAsync(GetProvaByIdRequest request);
        Task<Response<Prova?>> UpdateAsync(UpdateProvaRequest request);
    }
}
