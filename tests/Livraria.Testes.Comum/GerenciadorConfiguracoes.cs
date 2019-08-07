using Livraria.Api.Infraestrutura;
using Microsoft.Extensions.Configuration;

namespace Livraria.Testes.Comum
{
    public class GerenciadorConfiguracoes
    {
        public static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Localizador.ObterDiretorioDosAssembly())
                        .AddJsonFile("appsettings.json").AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
