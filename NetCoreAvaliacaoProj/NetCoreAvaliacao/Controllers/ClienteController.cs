using Microsoft.AspNetCore.Mvc;
using NetCoreAvaliacao.Application.DTOs;
using NetCoreAvaliacao.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("CadastraCliente")]
        public async Task<IActionResult> CadastraCliente(ClienteDTO clienteDTO)
        {
            return Ok(await _clienteService.SalvaCliente(clienteDTO));
        }

        [HttpGet("ConsultaCliente")]
        public async Task<IActionResult> ConsultaCliente(Guid idCliente)
        {
            return Ok(await _clienteService.RetornaCliente(idCliente));
        }

        [HttpPut("AtualizaCliente")]
        public async Task<IActionResult> AtualizaCliente(ClienteDTO clienteDTO)
        {
            return Ok(await _clienteService.AtualizaCliente(clienteDTO));
        }

        [HttpDelete("ApagaCliente")]
        public async Task<IActionResult> RemoveCliente(Guid idCliente)
        {
            return Ok(await _clienteService.RemoveCliente(idCliente));
        }

    }
}
