using FluentAssertions;
using Livraria.Api.Servicos;
using NUnit.Framework;
using System.Collections.Generic;

namespace Livraria.Testes.Unidade.Specs.Serviços
{
    class ServicoCalculadoraTest
    {
        private ServicoCalculadora _servicoCalculadora;

        [SetUp]
        public void SetUp() 
        {
            _servicoCalculadora = new ServicoCalculadora();
        }

        class SomarNumeros : ServicoCalculadoraTest 
        {
            [Test]
            public void DeveRetornarMenosUmCasoListaEstejaVazia() 
            {
                //arrange
                var resultadoEsperado = -1;
                var listaVazia = new List<int>();
                
                //action
                var resultado = _servicoCalculadora.SomarNumeros(listaVazia);

                //assert
                resultado.Should().Be(resultadoEsperado);
            }

            [Test]
            public void DeveRetornarSomaDosNumerosNaLista()
            {
                //arrange
                var lista = new List<int>() { 3, 4, 5, 10 };
                var resultadoEsperado = 22;

                //action
                var resultado = _servicoCalculadora.SomarNumeros(lista);

                //assert
                resultado.Should().Be(resultadoEsperado);
            }
        }
    }
}
