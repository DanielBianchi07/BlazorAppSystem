using Microsoft.AspNetCore.Routing;

namespace BlazorApp.Api.Common.Api
{
    public interface IEndPoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
