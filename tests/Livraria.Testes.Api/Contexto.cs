using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace Livraria.Testes.Api
{
    class Contexto
    {
        public static IConfiguration Configuration { get; set; }
        public static string DbName => Configuration["LiteDb:Name"];
        public static string DataBaseDirectory => Configuration["LiteDb:Endpoint"];
        public static string DbFullEndpoint => $@"{DataBaseDirectory}\{DbName}";
        public static string TestDbName => "Livraria_teste";
        public static HttpClient Client { get; set; }
    }
}
