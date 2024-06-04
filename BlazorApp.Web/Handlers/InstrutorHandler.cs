using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class InstrutorHandler(AppDbContext context) : IInstrutorHandler
    {
        public Task<Response<Instrutor?>> CreateAsync(CreateInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Instrutor?>> DeleteAsync(DeleteInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Instrutor>?>> GetAllAsync(GetAllInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Instrutor>?>> GetByEspecializacaoAsync(GetInstrutorByEspecializacaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Instrutor?>> GetByIdAsync(GetInstrutorByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Instrutor?>> UpdateAsync(UpdateInstrutorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
