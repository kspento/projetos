using NetCoreAvaliacao.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAvaliacao.Domain.Entities
{
    public sealed class Cliente
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome, int idade)
        {
            ValidateDomain(nome, idade);
        }

        private void ValidateDomain(string nome, int idade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome Invalido. Nome é requerido");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome Invalido. Nome tem que ter no minimo 3 caracteres");

            DomainExceptionValidation.When(nome.Length > 100,
                "Nome Invalido. Nome tem que ter no maximo 100 caracteres");

            DomainExceptionValidation.When(idade < 1,
                "Idade Invalida. A idade deve ser no mínimo 1 ano.");

            Nome = nome;

            Idade = idade;

        }
    }
}
