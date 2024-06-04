using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Responses
{
    // new Response<Empresa>
    // new Response<Prova>
    public class Response<TDados>
    {
        private int _code = Configuration.DefaultStatusCode;

        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;

        // var res = new Response<Empresa>(model)
        // optional parameters
        public Response(TDados? dados,
            int code = Configuration.DefaultStatusCode,
            string? message = null) 
        {
            Dados = dados;
            _code = code;
            Message = message;
        }

        public string? Message { get; set; }
        public TDados? Dados { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
