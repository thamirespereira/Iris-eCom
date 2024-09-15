using IrisECom.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisECom.Repositories.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_categorias");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(255);

            builder.Property(p => p.Imagem).HasColumnName("Imagem");
        }
    }
}
