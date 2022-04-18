
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAvaliacao.Domain.Entities;

namespace NetCoreAvaliacao.Infra.Data.EntitiesConfig
{
    internal class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(c => c.Idade)
                .IsRequired();

            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
