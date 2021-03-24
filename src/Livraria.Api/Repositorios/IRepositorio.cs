using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Api.Repositorios
{
    public interface IRepositorio<T>
    {
        List<T> ObterTodos();
        T ObterPorId(int elementoId);
        void Salvar(T elemento);
    }
}
