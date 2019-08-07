using LiteDB;
using Livraria.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Api.Repositorios
{
    public class Repositorio<T> where T : Entidade
    {
        private readonly string _nomeBaseDados;
        private readonly string _nomeColecao;

        public Repositorio(string nomeBaseDados, string nomeColecao)
        {
            _nomeBaseDados = nomeBaseDados;
            _nomeColecao = nomeColecao;
        }

        public List<T> ObterTodos()
        {
            using (var db = new LiteDatabase(_nomeBaseDados)) 
            {
                return db.GetCollection<T>(_nomeColecao).FindAll().ToList();
            }
        }

        public T ObterPorId(int elementoId)
        {
            using (var db = new LiteDatabase(_nomeBaseDados))
            {
                return db.GetCollection<T>(_nomeColecao)
                    .Find(x => x.Id == elementoId)
                    .FirstOrDefault();
            }
        }

        public void Salvar(T elemento)
        {
            using (var db = new LiteDatabase(_nomeBaseDados))
            {
                var a = db.GetCollection<T>(_nomeColecao).Insert(elemento);
            }
        }
    }
}
