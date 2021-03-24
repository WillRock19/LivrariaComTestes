using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace Livraria.Testes.Integracao.Api
{
    class Contexto
    {
        public static IConfiguration Configuration { get; set; }
        public static string DbName => Configuration["LiteDb:Name"];
        public static string DataBaseDirectory => Configuration["LiteDb:Endpoint"];
        public static string DbFullEndpoint => $@"{DataBaseDirectory}\{DbName}";
        public static string BackupDbName => "Livraria_backup";
        public static HttpClient Client { get; set; }
    }
}
