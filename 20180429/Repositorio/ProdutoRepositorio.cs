using _20180429.Helper.LogHelper;
using _20180429.Models;
using System.Collections.Generic;
using System.Linq;

namespace _20180429.Repositorio{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BDadosContext _contexto;
        public ProdutoRepositorio(BDadosContext bDadosContext)
        {
            _contexto = bDadosContext;
        }
        public void Criar(Produto produto)
        {
            _contexto.Add(produto);
            _contexto.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
        }

        public void Apagar(long id)
        {
            var entity = _contexto.Produtos.First(x => x.Produtos_id == id);
            _contexto.Produtos.Remove(entity);
            _contexto.SaveChanges();
        }

        public Produto ObterPorId(long id)
        {
            return _contexto.Produtos.FirstOrDefault(x => x.Produtos_id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var retorno = _contexto.Produtos.ToList();
            return (retorno.Count() > 0) ? retorno : null;
        }

        public IEnumerable<Produto> ObterPorNome(string nomeProduto)
        {
            var retorno = _contexto.Produtos.Where(w => w.nomeProduto.Contains(nomeProduto)).ToList();
            return (retorno.Count() > 0) ? retorno : null;
        }

    }
}