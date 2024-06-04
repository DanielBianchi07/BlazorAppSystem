using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface ICursoHandler
    {
        Task<Response<Curso?>> CreateAsync(CreateCursoRequest request);
        Task<Response<Curso?>> DeleteAsync(DeleteCursoRequest request);
        Task<PagedResponse<List<Curso>?>> GetAllAsync(GetAllCursosRequest request);
        Task<Response<Curso?>> GetByIdAsync(GetCursoByIdRequest request);
        Task<Response<Curso?>> UpdateAsync(UpdateCursoRequest request);
    }
}
