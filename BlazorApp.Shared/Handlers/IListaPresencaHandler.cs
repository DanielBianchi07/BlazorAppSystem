using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IListaPresencaHandler
    {
        Task<Response<ListaPresenca?>> CreateAsync(CreateListaPresencaRequest request);
        Task<Response<ListaPresenca?>> DeleteAsync(DeleteListaPresencaRequest request);
        Task<PagedResponse<List<ListaPresenca>?>> GetAllAsync(GetAllListaPresencaRequest request);
        Task<PagedResponse<List<ListaPresenca>?>> GetByDateAsync(GetListaPresencaByDateRequest request);
        Task<Response<ListaPresenca?>> GetByIdAsync(GetListaPresencaByIdRequest request);
        Task<Response<ListaPresenca?>> UpdateAsync(UpdateListaPresencaRequest request);
    }
}
