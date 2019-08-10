using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using _20180429.Models;
using _20180429.Repositorio;
using _20180429.Helper.LogHelper;

namespace _20180429.Controllers {
    [Route("api/[Controller]")]
    public class ProdutosController : Controller {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Produto produto) {
            try {
                if (produto == null) return BadRequest();
                _produtoRepositorio.Criar(produto);
                return CreatedAtRoute("ObterProdutoPorId", new {Produtos_id = produto.Produtos_id}, produto);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{Produtos_id}", Name = "AlterarProduto")]
        public IActionResult Alterar(long Produtos_id, [FromBody] Produto produto) {
            try {
                if (produto == null || produto.Produtos_id != Produtos_id) return BadRequest();
                var retorno = _produtoRepositorio.ObterPorId(Produtos_id);
                if (retorno == null) return NotFound();
                retorno.nomeProduto = produto.nomeProduto;
                _produtoRepositorio.Alterar(retorno);
                return CreatedAtRoute("ObterProdutoPorId", new {Produtos_id = retorno.Produtos_id}, retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{Produtos_id}")]
        public IActionResult Apagar(long Produtos_id) {
            try {
                var retorno = _produtoRepositorio.ObterPorId(Produtos_id);
                if (retorno == null) return NotFound();
                _produtoRepositorio.Apagar(Produtos_id);
                return new NoContentResult();
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{Produtos_id}", Name = "ObterProdutoPorId")]
        public IActionResult ObterPorId(long Produtos_id) {
            try {
                var retorno = _produtoRepositorio.ObterPorId(Produtos_id);
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("ObterTodos", Name = "ObterTodosProdutos")]
        public IActionResult ObterTodos() {
            try {
                var retorno = _produtoRepositorio.ObterTodos();
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("ObterPorNome", Name = "ObterProdutosPorNome")]
        public IActionResult ObterPorNome(string nomeProduto) {
            try {
                var retorno = _produtoRepositorio.ObterPorNome(nomeProduto);
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}