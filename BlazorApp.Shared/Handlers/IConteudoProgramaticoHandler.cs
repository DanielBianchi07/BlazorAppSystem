using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IConteudoProgramaticoHandler
    {
        Task<Response<ConteudoProgramatico?>> CreateAsync(CreateConteudoProgramaticoRequest request);
        Task<Response<ConteudoProgramatico?>> DeleteAsync(DeleteConteudoProgramaticoRequest request);
        Task<PagedResponse<List<ConteudoProgramatico>?>> GetAllAsync(GetAllConteudosProgramaticosRequest request);
        Task<PagedResponse<List<ConteudoProgramatico>?>> GetByCursoAsync(GetConteudoProgramaticoByCursoRequest request);
        Task<Response<ConteudoProgramatico?>> UpdateAsync(UpdateConteudoProgramaticoRequest request);
    }
}
