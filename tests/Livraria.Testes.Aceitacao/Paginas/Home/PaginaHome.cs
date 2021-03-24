using OpenQA.Selenium;

namespace Livraria.Testes.Aceitacao.Paginas.Home
{
    class PaginaHome : PaginaBase
    {
        public override string Url => "/";

        public bool BannerEstaVisivel() 
            => ElementoEstaVisivel("BannerPrincipal");

        public SubPaginaConteudo NavegarPaginaConteudo()
        {
            var elemento = Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
            elemento.Click();

            return new SubPaginaConteudo();
        }

        private bool ElementoEstaVisivel(string idElemento) 
        {
            var elemento = Driver.FindElement(By.Id(idElemento));
            return elemento.Displayed;
        }
    }
}
