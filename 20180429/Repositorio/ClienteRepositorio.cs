using _20180429.Helper.LogHelper;
using _20180429.Models;
using System.Collections.Generic;
using System.Linq;

namespace _20180429.Repositorio{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BDadosContext _contexto;
        public ClienteRepositorio(BDadosContext bDadosContext)
        {
            _contexto = bDadosContext;
        }
        public void Criar(Cliente cliente)
        {
            _contexto.Add(cliente);
            _contexto.SaveChanges();
        }

        public void Alterar(Cliente cliente)
        {
            _contexto.Clientes.Update(cliente);
            _contexto.SaveChanges();
        }

        public void Apagar(long id)
        {
            var entity = _contexto.Clientes.First(x => x.Clientes_id == id);
            _contexto.Clientes.Remove(entity);
            _contexto.SaveChanges();
        }

        public Cliente ObterPorId(long id)
        {
            return _contexto.Clientes.FirstOrDefault(x => x.Clientes_id == id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var retorno = _contexto.Clientes.ToList();
            return (retorno.Count() > 0) ? retorno : null;
        }

        public IEnumerable<Cliente> ObterPorNome(string nomeCliente)
        {
            var retorno = _contexto.Clientes.Where(w => w.nomeCliente.Contains(nomeCliente)).ToList();
            return (retorno.Count() > 0) ? retorno : null;
        }

    }
}