using OpenQA.Selenium;

namespace Livraria.Testes.Aceitacao.Paginas.Home
{
    class SubPaginaConteudo : PaginaBase
    {
        public override string Url => "/Home/Privacy";

        public string ObterMensagemProvocativa()
        {
            var elemento = Driver.FindElement(By.Id("MensagemProvocativa"));
            return elemento.Text;
        }
    }
}
