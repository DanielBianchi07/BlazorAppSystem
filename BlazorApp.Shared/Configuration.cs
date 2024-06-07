using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;

        public static string BackendUrl { get; set; } = "http://localhost:5239";
        public static string FrontendUrl { get; set; } = "http://localhost:5235";
    }
}
