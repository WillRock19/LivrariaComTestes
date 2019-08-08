using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Livraria.Testes.Aceitacao
{
    class GerenciadorWebDriver
    {
        public static IWebDriver Driver { get; private set; }

        public static void Inicializar()
        {
            var option = new ChromeOptions();
            var pathWebDriver = Directory.GetCurrentDirectory();

            //option.AddArguments("--headless");
            option.AddArguments("--disable-gpu");
            option.AddArguments("--window-size=1920,1080");
            option.AddArguments("--no-sandbox");

            Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(pathWebDriver), option, TimeSpan.FromMinutes(5));
        }
    }
}
