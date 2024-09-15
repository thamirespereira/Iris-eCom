using IrisECom.Models;
using Microsoft.EntityFrameworkCore;

namespace IrisECom.Repositories.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(255);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao");

            builder.Property(p => p.Preco)
                .HasColumnName("Preco");

            builder.Property(p => p.InfoTecnica)
                .HasColumnName("InfoTecnica");

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade");

            builder.Property(p => p.Imagem)
                .HasColumnName("Imagem");

            //builder.Property(p => p.CategoriaId).HasColumnName("CategoriaId");

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Produtos)
                .HasForeignKey(p =>p.UsuarioId);
        }
    }
}
