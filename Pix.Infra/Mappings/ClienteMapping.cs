using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pix.Domain;

namespace Pix.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("id");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnName("codigo")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.QuantidadeItens)
              .IsRequired()
              .HasColumnName("quantidade_itens")
              .HasColumnType("int");

            builder.ToTable("clientes");
        }
    }
}
