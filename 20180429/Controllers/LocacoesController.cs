using _20180429.Models;
using _20180429.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _20180429.Controllers {
    [Route("api/[Controller]")]
    public class LocacoesController : Controller {
        private readonly ILocacaoRepositorio _locacaoRepositorio;
        public LocacoesController(ILocacaoRepositorio locacaoRepositorio)
        {
            _locacaoRepositorio = locacaoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Locacao> GetAll() {
            return _locacaoRepositorio.GetAll();
        }

        [HttpGet("{Locacoes_id}", Name="GetLocacao")]
        public IActionResult GetById(long Locacoes_id) {
            var _locacao = _locacaoRepositorio.Find(Locacoes_id);
            if (_locacao == null) return NotFound();
            return new ObjectResult(_locacao);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Locacao locacao) {
            if (locacao == null) return BadRequest();
            _locacaoRepositorio.Add(locacao);
            return CreatedAtRoute("GetLocacao", new {Locacoes_id = locacao.Locacoes_id}, locacao);
        }

        [HttpPut("{Locacoes_id}")]
        public IActionResult Update(long Locacoes_id, [FromBody] Locacao locacao) {
            if (locacao == null || locacao.Locacoes_id != Locacoes_id) return BadRequest();
            var _locacao = _locacaoRepositorio.Find(Locacoes_id);
            if (_locacao == null) return NotFound();
            _locacao.dtReserva = locacao.dtReserva;
            _locacao.dtRetirada = locacao.dtRetirada;
            _locacao.dtDevolucao = locacao.dtDevolucao;
            _locacaoRepositorio.Update(_locacao);
            return new NoContentResult();
        }

        [HttpDelete("{Locacoes_id}")]
        public IActionResult Delete(long Locacoes_id) {
            var _locacao = _locacaoRepositorio.Find(Locacoes_id);
            if (_locacao == null) return NotFound();
            _locacaoRepositorio.Remove(Locacoes_id);
            return new NoContentResult();
        }
    }
}