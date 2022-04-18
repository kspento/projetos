using NetCoreAvaliacao.Domain.Entities;
using NetCoreAvaliacao.Domain.Interfaces;
using NetCoreAvaliacao.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {    
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AtualizaCliente(Cliente cliente)
        {
            var entity = _appDbContext.Clientes.Update(cliente);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Cliente> IncluiNovoCliente(Cliente cliente)
        {
            var entity = _appDbContext.Add(cliente);
            await _appDbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<bool> RemoveCliente(Cliente cliente)
        {
            _appDbContext.Clientes.Remove(cliente);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> RetornaCLientePorId(Guid id)
        {
            return  await _appDbContext.Clientes.FindAsync(id);
        }
    }
}
