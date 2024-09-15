using IrisECom.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisECom.Repositories.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuarios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Nome).HasColumnName("Nome");

            builder.Property(p => p.Email).HasColumnName("Email");

            builder.Property(p => p.Senha).HasColumnName("Senha");

            builder.Property(p => p.CEP).HasColumnName("CEP");

            builder.Property(p => p.Endereco).HasColumnName("Endereco");

            builder.Property(p => p.Bairro).HasColumnName("Bairro");

            builder.Property(p => p.Cidade).HasColumnName("Cidade");

            builder.Property(p => p.UF).HasColumnName("UF");

            builder.Property(p => p.CPF).HasColumnName("CPF");

            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento");

            builder.Property(p => p.Imagem).HasColumnName("Imagem");
        }
    }
}
