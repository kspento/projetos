using NetCoreAvaliacao.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Application.Interfaces
{
    public interface IClienteService
    {
        Task<bool> RemoveCliente(Guid id);
        Task<ClienteDTO> RetornaCliente(Guid id);
        Task<string> SalvaCliente(ClienteDTO userDTO);
        Task<ClienteDTO> AtualizaCliente(ClienteDTO cliente);
    }
}