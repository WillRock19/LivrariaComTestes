using Livraria.Api.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Funcionalidades.Catalogo
{
    public class CatalogoController : ControllerBase
    {
        [HttpGet("{livroId}")]
        public ActionResult ObterLivro(int livroId)
        {
            return Ok(new ResultadoApi());
        }

        [HttpGet]
        public ActionResult ObterLivros()
        {
            return Ok(new ResultadoApi());
        }

        [HttpPost]
        public ActionResult SalvarLivros()
        {
            return NotFound("Funcionalidade não implementada");
        }
    }
}
