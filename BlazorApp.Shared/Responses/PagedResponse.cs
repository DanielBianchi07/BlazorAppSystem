using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Responses
{
    public class PagedResponse<TDados> : Response<TDados>
    {
        [JsonConstructor]
        public PagedResponse(
            TDados? dados,
            int totalCount,
            int currentPage = 1,
            int pageSize = Configuration.DefaultPageSize)
            : base(dados)
        {
            Dados = dados;
            TotalCount = totalCount;
            CurrentPage = currentPage;  
            PageSize = pageSize;
        }

        public PagedResponse(
            TDados? dados,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
            : base(dados, code, message) 
        {
        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
