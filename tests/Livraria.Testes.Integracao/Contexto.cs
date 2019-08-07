using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Testes.Integracao
{
    class Contexto
    {
        public static IConfiguration Configuration { get; set; }
        public static string DbName => Configuration["LiteDb:Name"];
        public static string DataBaseDirectory => Configuration["LiteDb:Endpoint"];
        public static string DbFullEndpoint => $@"{DataBaseDirectory}\{DbName}";
        public static string TestDbName => "Livraria_teste";
    }
}
