using System;

namespace NetCoreAvaliacao.Application.DTOs
{
    public class ClienteDTO
    {
        public Guid IdCliente { get; set; }  
        public string NomeCliente { get; set; }
        public int IdadeCliente { get; set; }

    }
}
