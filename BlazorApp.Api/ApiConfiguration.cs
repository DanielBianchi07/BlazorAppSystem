using System.Globalization;

namespace BlazorApp.Api
{
    public class ApiConfiguration
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string CorsPolicyName = "wasm";
    }
}
