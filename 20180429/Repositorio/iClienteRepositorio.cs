using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using _20180429.Models;

namespace _20180429.Repositorio{
    public interface IClienteRepositorio {
        void Criar(Cliente cliente);
        void Alterar(Cliente cliente);
        void Apagar(long id);
        Cliente ObterPorId(long id);
        IEnumerable<Cliente> ObterTodos();
        IEnumerable<Cliente> ObterPorNome(string nomeCliente);
    }
}