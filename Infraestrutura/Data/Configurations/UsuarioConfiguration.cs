using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sobrenome)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Senha)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
