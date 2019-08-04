using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Livraria.Api.Funcionalidades.Catalogo
{
    public class CatalogoController : ControllerBase
    {
        private readonly LivroRepositorio _livroRepository;

        public CatalogoController(LivroRepositorio livroRepository)
        {
            _livroRepository = livroRepository;
        }


        [HttpGet("{livroId}")]
        public async Task<ActionResult> ObterLivro(int livroId)
        {
            if (livroId == 0)
                return BadRequest(new ResultadoApi("Id do livro desejado deve ser informado"));

            var livro = await _livroRepository.ObterLivro(livroId);

            return Ok(new ResultadoApi
            {
                Sucesso = true,
                Dados = livro
            });
        }

        [HttpGet]
        public ActionResult ObterLivros()
        {
            return Ok(new ResultadoApi());
        }

        [HttpPost]
        public ActionResult SalvarLivros()
        {
            return NotFound(new ResultadoApi("Funcionalidade não implementada"));
        }
    }
}
