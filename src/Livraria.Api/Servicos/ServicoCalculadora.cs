using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Api.Servicos
{
    public class ServicoCalculadora
    {
        public long SomarNumeros(List<int> numeros) 
        {
            if (numeros.Count == 0)
                return -1;

            return numeros.Sum();
        }
    }
}
