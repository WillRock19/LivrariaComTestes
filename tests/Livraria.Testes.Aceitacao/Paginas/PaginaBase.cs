using OpenQA.Selenium;

namespace Livraria.Testes.Aceitacao.Paginas
{
    abstract class PaginaBase
    {
        public IWebDriver Driver => GerenciadorWebDriver.Driver;
        public string UrlBase => Contexto.UrlBaseLivraria;
        public abstract string Url { get; }
        public void Navegar() => 
            Driver?.Navigate().GoToUrl($"{UrlBase}{Url}");

        public string ObterUrlAtualDoNavegador() =>
            Driver?.Url;
    }
}
