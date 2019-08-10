using _20180429.Models;
using System.Collections.Generic;
using System.Linq;

namespace _20180429.Repositorio {
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private readonly BDadosContext _contexto;
        public LocacaoRepositorio(BDadosContext bDadosContext)
        {
            _contexto = bDadosContext;
        }
        public void Add(Locacao locacao)
        {
            _contexto.Add(locacao);
            _contexto.SaveChanges();
        }

        public Locacao Find(long id)
        {
            return _contexto.Locacoes.FirstOrDefault(x => x.Locacoes_id == id);
        }

        public IEnumerable<Locacao> GetAll()
        {
            return _contexto.Locacoes.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Locacoes.First(x => x.Locacoes_id == id);
            _contexto.Locacoes.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Locacao locacao)
        {
            _contexto.Locacoes.Update(locacao);
            _contexto.SaveChanges();
        }
    }
}