using NetCoreAvaliacao.Application.DTOs;
using NetCoreAvaliacao.Application.Helpers;
using NetCoreAvaliacao.Application.Interfaces;
using NetCoreAvaliacao.Domain.Entities;
using NetCoreAvaliacao.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<string> SalvaCliente(ClienteDTO userDTO)
        {
            var message = string.Empty;

            var userEntity = new Cliente(userDTO.NomeCliente, userDTO.IdadeCliente);

            var entity = await _clienteRepository.IncluiNovoCliente(userEntity);

            return entity.Id.ToString();
        }

        public async Task<ClienteDTO> RetornaCliente(Guid id)
        {
            var clienteEntity = await _clienteRepository.RetornaCLientePorId(id);

            if (clienteEntity == null)
            {
                throw new AppException("Cliente não encontrado");
            }

            var model = new ClienteDTO
            {
                IdCliente = clienteEntity.Id,

                NomeCliente = clienteEntity.Nome,

                IdadeCliente = clienteEntity.Idade
            };

            return model;
        }

        public async Task<bool> RemoveCliente(Guid id)
        {
            var clienteEntity = await _clienteRepository.RetornaCLientePorId(id);

            if (clienteEntity == null)
            {
                throw new AppException("Cliente não encontrado");
            }
            return await _clienteRepository.RemoveCliente(clienteEntity);
        }

        public async Task<ClienteDTO> AtualizaCliente (ClienteDTO cliente)
        {
            var clienteEntity = await _clienteRepository.RetornaCLientePorId(cliente.IdCliente);

            if (clienteEntity == null)
            {
                throw new AppException("Cliente não encontrado");
            }              

            clienteEntity.Idade = cliente.IdadeCliente;
            clienteEntity.Nome = cliente.NomeCliente;
            await _clienteRepository.AtualizaCliente(clienteEntity);

            cliente.IdCliente = clienteEntity.Id;

            return cliente;

        }
    }
}
