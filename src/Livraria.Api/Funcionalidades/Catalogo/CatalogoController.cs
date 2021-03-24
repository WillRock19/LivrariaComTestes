using Livraria.Api.Entidades;
using Livraria.Api.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.Api.Funcionalidades.Catalogo
{
    [Route("api/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly IRepositorio<Livro> _livroRepositorio;

        public CatalogoController(IRepositorio<Livro> livroRepository)
        {
            _livroRepositorio = livroRepository;
        }

        [HttpGet]
        public ActionResult ObterLivro([FromQuery]int livroId)
        {
            if (livroId == 0)
                return BadRequest(new ResultadoApi("Favor, informar o livroId do livro desejado"));

            try
            {
                var livro = _livroRepositorio.ObterPorId(livroId);

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

        [HttpGet("livros")]
        public ActionResult ObterLivros()
        {
            try
            {
                var livros = _livroRepositorio.ObterTodos();

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
            try
            {
                _livroRepositorio.Salvar(new Livro { NomeAutor = "Teste" });
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(new ResultadoApi($"O seguinte erro ocorreu ao acessar a base de dados: {erro.Message}"));
            }


            //return NotFound(new ResultadoApi("Funcionalidade não implementada"));
        }
    }
}
