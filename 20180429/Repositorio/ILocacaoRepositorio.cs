using System.Collections.Generic;
using _20180429.Models;

namespace _20180429.Repositorio{
    public interface ILocacaoRepositorio {
        void Add(Locacao locacao);
        IEnumerable<Locacao> GetAll();
        Locacao Find(long id);
        void Remove(long id);
        void Update(Locacao locacao);
    }
}