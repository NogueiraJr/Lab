using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using _20180429.Models;

namespace _20180429.Repositorio{
    public interface IProdutoRepositorio {
        void Criar(Produto cliente);
        void Alterar(Produto cliente);
        void Apagar(long id);
        Produto ObterPorId(long id);
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPorNome(string nomeProduto);
    }
}