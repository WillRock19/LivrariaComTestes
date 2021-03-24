using OpenQA.Selenium;

namespace Livraria.Testes.Aceitacao.Paginas.Home
{
    class PaginaHome : PaginaBase
    {
        public override string Url => "/";

        public bool BannerEstaVisivel() 
            => ElementoEstaVisivel("BannerPrincipal");

        public string ObterMensagemProvocativa()
        {
            return Driver.FindElement(By.Id("MensagemProvocativa")).Text;
        }

        private bool ElementoEstaVisivel(string idElemento) 
        {
            var elemento = Driver.FindElement(By.Id(idElemento));
            return elemento.Displayed;
        }
    }
}
