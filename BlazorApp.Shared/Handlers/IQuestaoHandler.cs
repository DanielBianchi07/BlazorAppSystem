using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IQuestaoHandler
    {
        Task<Response<Questao?>> CreateAsync(CreateQuestaoRequest request);
        Task<Response<Questao?>> DeleteAsync(DeleteQuestaoRequest request);
        Task<Response<Questao?>> GetByIdAsync(GetQuestaoByIdRequest request);
        Task<PagedResponse<List<Questao>?>> GetByProvaAsync(GetQuestaoByProvaRequest request);
        Task<Response<Questao?>> UpdateAsync(UpdateQuestaoRequest request);
    }
}
