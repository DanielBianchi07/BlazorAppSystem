using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class ListaPresencaHandler(AppDbContext context) : IListaPresensaHandler
    {
        public Task<Response<ListaPresenca?>> CreateAsync(CreateListaPresencaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ListaPresenca?>> DeleteAsync(DeleteListaPresencaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ListaPresenca?>> GetByIdAsync(GetListaPresencaByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<ListaPresenca>?>> GetByTreinamentoAsync(GetListaPresencaByTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ListaPresenca?>> UpdateAsync(UpdateListaPresencaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
