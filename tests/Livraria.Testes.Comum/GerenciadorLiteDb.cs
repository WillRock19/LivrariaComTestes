using System.IO;

namespace Livraria.Testes.Comum
{
    public static class GerenciadorLiteDb
    {
        public static void CriarBackupBaseCasoNaoExista(string diretorioDb, string nomeBaseBackup, string nomeBasePrincipal)
        {
            var pathBaseBackup = $@"{diretorioDb}\{nomeBaseBackup}";
            var pathDataBase = $@"{diretorioDb}\{nomeBasePrincipal}";

            if (!File.Exists(pathBaseBackup) && File.Exists(pathDataBase))
                File.Copy(pathDataBase, pathBaseBackup);
        }

        public static void RestaurarBackupComoBasePrincipal(string diretorioDb, string nomeBaseBackup, string nomeBasePrincipal)
        {
            var pathBaseBackup = $@"{diretorioDb}\{nomeBaseBackup}";
            var pathDataBase = $@"{diretorioDb}\{nomeBasePrincipal}";

            if (File.Exists(pathBaseBackup))
            {
                File.Delete(pathDataBase);
                File.Move(pathBaseBackup, pathDataBase);
            }
        }

        public static void RecriarColecaoAPartirDoBackup(string diretorioDb, string nomeBaseBackup, string nomeBasePrincipal)
        {
            var pathBaseBackup = $@"{diretorioDb}\{nomeBaseBackup}";
            var pathDataBase = $@"{diretorioDb}\{nomeBasePrincipal}";

            if (File.Exists(pathBaseBackup))
            {
                File.Delete(pathDataBase);
                File.Copy(pathBaseBackup, pathDataBase);
            }
        }
    }
}
