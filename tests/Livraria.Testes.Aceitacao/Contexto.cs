using Microsoft.Extensions.Configuration;

namespace Livraria.Testes.Aceitacao
{
    class Contexto
    {
        public static IConfiguration Configuration { get; set; }
        public static string DbName => Configuration["LiteDb:Name"];
        public static string DataBaseDirectory => Configuration["LiteDb:Endpoint"];
        public static string DbFullEndpoint => $@"{DataBaseDirectory}\{DbName}";
        public static string BackupDbName => "Livraria_backup";
        public static string UrlBaseLivraria => Configuration["AcceptanceTestUrl"];
    }
}
