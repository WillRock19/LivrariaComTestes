using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Livraria.Api.Funcionalidades.Catalogo
{
    [Route("api/[controller]")]
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
                return BadRequest(new ResultadoApi("Favor, informar o livroId do livro desejado"));

            try
            {
                var livro = await _livroRepository.ObterLivro(livroId);

                if (livro == null)
                    return NotFound(new ResultadoApi($"Livro {livroId} não foi encontrado!"));

                return Ok(new ResultadoApi
                {
                    Sucesso = true,
                    Dados = livro
                });
            }
            catch(Exception erro) {
                return BadRequest(new ResultadoApi($"O seguinte erro ocorreu ao acessar a base de dados: {erro.Message}"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> ObterLivros()
        {
            try
            {
                var livros = await _livroRepository.ObterLivros();

                return Ok(new ResultadoApi
                {
                    Sucesso = true,
                    Dados = livros
                });
            }
            catch (Exception erro) {
                return BadRequest(new ResultadoApi($"O seguinte erro ocorreu ao acessar a base de dados: {erro.Message}"));
            }
        }

        [HttpPost]
        public ActionResult SalvarLivros()
        {
            return NotFound(new ResultadoApi("Funcionalidade não implementada"));
        }
    }
}
