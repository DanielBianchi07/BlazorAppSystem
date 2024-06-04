using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IAlternativaHandler
    {
        Task<Response<Alternativa?>> CreateAsync(CreateAlternativaRequest request);
        Task<Response<Alternativa?>> DeleteAsync(DeleteAlternativaRequest request);
        Task<Response<Alternativa?>> GetByIdAsync(GetAlternativaByIdRequest request);
        Task<PagedResponse<List<Alternativa>?>> GetByQuestaoAsync(GetAlternativasByQuestaoRequest request);
        Task<Response<Alternativa?>> UpdateAsync(UpdateAlternativaRequest request);
    }
}
