using System;
using System.IO;
using System.Reflection;

namespace Livraria.Api.Infraestrutura
{
    public static class Localizador
    {
        public static string ObterCaminhoDaSolution()
        {
            var diretorio = new DirectoryInfo(ObterDiretorioDosAssembly());

            while (diretorio != null && diretorio.GetFiles("*.sln").Length == 0)
            {
                diretorio = diretorio.Parent;
            }

            if (diretorio == null)
                throw new DirectoryNotFoundException();

            return diretorio.FullName;
        }

        public static string ObterDiretorioDosAssembly()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
