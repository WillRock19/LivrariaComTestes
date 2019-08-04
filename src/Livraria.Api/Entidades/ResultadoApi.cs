using System.Collections.Generic;

namespace Livraria.Api.Entidades
{
    public class ResultadoApi
    {
        public object Dados { get; set; }
        public bool Sucesso { get; set; }
        public List<string> Notificacoes { get; set; }

        public ResultadoApi()
        {
            Notificacoes = new List<string>();
        }

        public ResultadoApi(string notificacao)
        {
            Sucesso = false;
            Notificacoes = new List<string>() { notificacao };
        }
    }
}
