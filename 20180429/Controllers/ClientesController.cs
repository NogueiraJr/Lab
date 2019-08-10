using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using _20180429.Models;
using _20180429.Repositorio;
using _20180429.Helper.LogHelper;

namespace _20180429.Controllers {
    [Route("api/[Controller]")]
    public class ClientesController : Controller {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Cliente cliente) {
            try {
                if (cliente == null) return BadRequest();
                _clienteRepositorio.Criar(cliente);
                return CreatedAtRoute("ObterClientePorId", new {Clientes_id = cliente.Clientes_id}, cliente);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{Clientes_id}", Name = "AlterarCliente")]
        public IActionResult Alterar(long Clientes_id, [FromBody] Cliente cliente) {
            try {
                if (cliente == null || cliente.Clientes_id != Clientes_id) return BadRequest();
                var retorno = _clienteRepositorio.ObterPorId(Clientes_id);
                if (retorno == null) return NotFound();
                retorno.nomeCliente = cliente.nomeCliente;
                _clienteRepositorio.Alterar(retorno);
                return CreatedAtRoute("ObterClientePorId", new {Clientes_id = retorno.Clientes_id}, retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{Clientes_id}")]
        public IActionResult Apagar(long Clientes_id) {
            try {
                var retorno = _clienteRepositorio.ObterPorId(Clientes_id);
                if (retorno == null) return NotFound();
                _clienteRepositorio.Apagar(Clientes_id);
                return new NoContentResult();
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{Clientes_id}", Name = "ObterClientePorId")]
        public IActionResult ObterPorId(long Clientes_id) {
            try {
                var retorno = _clienteRepositorio.ObterPorId(Clientes_id);
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("ObterTodos", Name = "ObterTodosClientes")]
        public IActionResult ObterTodos() {
            try {
                var retorno = _clienteRepositorio.ObterTodos();
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("ObterPorNome", Name = "ObterClientesPorNome")]
        public IActionResult ObterPorNome(string nomeCliente) {
            try {
                var retorno = _clienteRepositorio.ObterPorNome(nomeCliente);
                if (retorno == null) return NotFound();
                return new ObjectResult(retorno);
            } catch (Exception ex) {
                (new LogInfo()).RegLogError(ex);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}